using System;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;
using ServiceStack.Text;

namespace Game
{
	public class Game: WebSocketService
	{
		private static Dictionary<String, Model.Player> players = new Dictionary<String, Model.Player>(100);
		private Model.Player player;

		private static Store.Questions questions = new Store.Questions();
		private static Dictionary<String, Int32[]> answers = new Dictionary<String, Int32[]>();
		private static Dictionary<String, Double> results = new Dictionary<String, Double>();

		protected override void OnMessage(MessageEventArgs e)
		{
			Game.players.TryGetValue (this.ID, out this.player);
			var data = JsonSerializer.DeserializeFromString<JsonObject>(e.Data);
			Model.Player opponent;
			switch(data.Get("method")){
			case "login":
				this.Login (this.ID, data.Get("name"), data.Get<Int32>("gender"));
				break;
			case "invite":
				Game.players.TryGetValue (data.Get("id"), out opponent);
				this.Invite (opponent);
				break;
			case "startGame":
				Game.players.TryGetValue (data.Get("id"), out opponent);
				this.StartGame (opponent);
				break;
			case "stopGame":
				this.StopGame ();
				break;
			case "answer":
				this.Answer (data.Get<Int32>("answer"));
				break;
			}
		}

		protected override void OnClose (CloseEventArgs e)
		{
			if (this.player == null) {
				return;
			}
			Game.players.Remove (this.player.id);
			Console.WriteLine ("Remove player with id: {0}", this.player.id);
			this.Sessions.BroadcastAsync (JsonSerializer.SerializeToString(new {
				method = "remove", 
				player = this.player,
			}), null);
		}

		private void Login (String id, String name, Int32 gender)
		{
			Model.Player newPlayer = new Model.Player () {
				id = id,
				name = name,
				gender = (Model.Player.Gender)gender,
			};

			Game.players.Add(newPlayer.id, newPlayer);

			this.Sessions.BroadcastAsync (JsonSerializer.SerializeToString(new {
				method = "add",
				player = newPlayer,
			}), null);

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "players",
				players = Game.players,
			}), null);
		}

		private void Invite (Model.Player opponent)
		{
			String error = "";
			if (opponent == null) {
				error = "Player is not in the game";
			} else if (this.player == null) {
				error = "You are not in the game";
			} else if (this.player.gender == opponent.gender) {
				error = "You cannot invite player with same gender";
			}

			if (!String.IsNullOrEmpty(error)) {
				this.SendAsync (JsonSerializer.SerializeToString(new {
					method = "invite",
					error = error,
				}), null);
				return;
			}

			opponent.invites [this.player.id] = this.player;

			this.Sessions.SendToAsync (opponent.id, JsonSerializer.SerializeToString(new {
				method = "invite", 
				player = this.player,
			}), null);
		}

		private void StartGame (Model.Player opponent)
		{
			String error = "";
			if (this.player == null) {
				error = "Player is not in the Game";
			} else if (opponent.pair != null) {
				error = "Player is playing";
			} else if (this.player.pair != null) {
				error = "You are playing";
			} else if (!this.player.invites.ContainsKey(opponent.id)) {
				error = "Player has not invited you";
			}

			if (!String.IsNullOrEmpty(error)) {
				this.SendAsync (JsonSerializer.SerializeToString(new {
					method = "startGame",
					error = error,
				}), null);
				return;
			}

			Model.Pair pair = new Model.Pair () { 
				player1 = this.player,
				player2 = opponent,
			};

			this.player.pair = pair;
			opponent.pair = pair;

			this.player.invites.Remove (opponent.id);
			// Game.invites[id].Remove(this.ID);

			// answers count, right answers count, answer1, answer2
			Game.answers [pair.Id] = new [] {0, 0, 0, 0};
			Dictionary<String, String> question = questions.getQuestion (this.player, opponent);

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "startGame",
				success = true,
				player = opponent,
				question = question[this.player.id],
			}), null);

			this.Sessions.SendToAsync (opponent.id, JsonSerializer.SerializeToString(new {
				method = "startGame",
				success = true,
				player = this.player,
				question = question[opponent.id],
			}), null);
		}

		private void StopGame ()
		{
			if (this.player.Opponent != null) {
				this.Sessions.SendToAsync (this.player.Opponent.id, JsonSerializer.SerializeToString(new {
					method = "stopGame",
				}), null);
			}

			this.finishGame ();
		}

		private void finishGame ()
		{
			if (this.player.pair != null) {
				this.player.Opponent.pair = null;
				Game.answers.Remove (this.player.pair.Id);
			}
			this.player.pair = null;

		}

		private void Answer (Int32 answer)
		{
			if (this.player == null || this.player.pair == null) {
				this.SendAsync (JsonSerializer.SerializeToString(new {
					method = "answer",
					error = "You are not playing",
				}), null);
				return;
			}

			String pairId = this.player.pair.Id;

			Int32 thisAnswerPos = 2;
			Int32 answerPos = 3;
			if (String.Compare(this.player.Opponent.id, this.player.id) < 0) {
				thisAnswerPos = 3;
				answerPos = 2;
			}

			Game.answers [pairId] [thisAnswerPos] = answer;

			// another player not answered yet
			if (Game.answers [pairId] [answerPos] == 0) {
				return;
			}

			Game.answers[pairId][0]++;

			// same answer
			if (Game.answers[pairId][answerPos] == answer) {
				Game.answers[pairId][1]++;
			}

			Double result = 0;

			// calc result
			if (Game.answers[pairId][0] >= 10) {
				result = (Game.answers [pairId] [1] * 100) / Game.answers [pairId] [0];
			}

			Dictionary<String, String> question = questions.getQuestion (this.player, this.player.Opponent);

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "answer",
				answer = Game.answers [pairId] [answerPos],
				result = result,
				question = question[this.player.id],
			}), null);

			this.Sessions.SendToAsync (this.player.Opponent.id, JsonSerializer.SerializeToString(new {
				method = "answer",
				answer = answer,
				result = result,
				question = question[this.player.Opponent.id],
			}), null);

			Game.answers [pairId] [2] = 0;
			Game.answers [pairId] [3] = 0;

			// finish game
			if (result > 0) {
				this.finishGame ();
				Game.results[pairId] = result;
			}
		}
	}
}

