using System;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;
using ServiceStack.Text;

namespace Game
{
	public class Game: WebSocketService
	{
		private static Dictionary<String, String> players = new Dictionary<String, String>();
		private static Dictionary<String, String> playing = new Dictionary<String, String>();
		private static Dictionary<String, Dictionary<String, String>> invites = new Dictionary<String, Dictionary<String, String>>();
		private static Dictionary<String, Int32[]> answers = new Dictionary<String, Int32[]>();
		private static Dictionary<String, Double> results = new Dictionary<String, Double>();

		protected override void OnMessage(MessageEventArgs e)
		{
			var data = JsonSerializer.DeserializeFromString<JsonObject>(e.Data);
			switch(data.Get("method")){
			case "login":
				this.Login (this.ID, data.Get("name"));
				break;
			case "invite":
				this.Invite (data.Get("id"));
				break;
			case "startGame":
				this.StartGame (data.Get("id"));
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
			Game.players.Remove (this.ID);
			Game.playing.Remove (this.ID);
			Game.invites.Remove (this.ID);
			Console.WriteLine ("Remove id: {0}", this.ID);
			this.Sessions.BroadcastAsync (JsonSerializer.SerializeToString(new {
				method = "remove", 
				id = this.ID,
			}), null);
		}

		private void Login (String id, String name)
		{
			Game.players [id] = name;
			Console.WriteLine ("Players count: {0}", Game.players.Count);

			this.Sessions.BroadcastAsync (JsonSerializer.SerializeToString(new {
				method = "add",
				id = id, 
				name = name,
			}), null);

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "players",
				id = this.ID,
				players = Game.players,
			}), null);
		}

		private void Invite (String id)
		{
			if (!Game.invites.ContainsKey (id)) {
				Game.invites[id] = new Dictionary<String, String>();
			}
			Game.invites [id] [this.ID] = this.ID;
			this.Sessions.SendToAsync (id, JsonSerializer.SerializeToString(new {
				method = "invite", 
				id = this.ID,
				name = Game.players[this.ID],
			}), null);
		}

		private void StartGame (String id)
		{
			String error = "";
			if (!Game.players.ContainsKey(id)) {
				error = "Player is not in the Game";
			} else if (Game.playing.ContainsKey(id)) {
				error = "Player is playing";
			} else if (Game.playing.ContainsKey (this.ID)) {
				error = "You are playing";
			} else if (!Game.invites.ContainsKey(this.ID) || !Game.invites[this.ID].ContainsKey(id)) {
				error = "Player has not invited you";
			}

			if (!String.IsNullOrEmpty(error)) {
				this.SendAsync (JsonSerializer.SerializeToString(new {
					method = "startGame",
					success = false,
					message = error
				}), null);
				return;
			}

			String pairId = this.CreatePairId(id, this.ID);
			Game.playing [this.ID] = id;
			Game.playing [id] = this.ID;

			Game.invites[this.ID].Remove(id);
			// Game.invites[id].Remove(this.ID);

			// answers count, right answers count, answer1, answer2
			Game.answers [pairId] = new [] {0, 0, 0, 0};

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "startGame",
				success = true,
				id = id,
				message = "Start game"
			}), null);

			this.Sessions.SendToAsync (id, JsonSerializer.SerializeToString(new {
				method = "startGame",
				success = true,
				id = this.ID,
				message = "Start game"
			}), null);
		}

		private void StopGame ()
		{
			String id = Game.playing [this.ID];

			this.Sessions.SendToAsync (id, JsonSerializer.SerializeToString(new {
				method = "stopGame",
			}), null);

			this.finishGame ();
		}

		private void finishGame ()
		{
			String id = Game.playing [this.ID];

			Game.playing.Remove (id);
			Game.playing.Remove (this.ID);
			Game.answers.Remove (this.CreatePairId(id, this.ID));
		}

		private void Answer (Int32 answer)
		{
			String id = Game.playing[this.ID];
			String pairId = this.CreatePairId (id, this.ID);

			Int32 thisAnswerPos = 2;
			Int32 answerPos = 3;
			if (String.Compare(id, this.ID) < 0) {
				answerPos = 2;
				thisAnswerPos = 3;
			}

			Game.answers[pairId][thisAnswerPos] = answer;

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

			this.SendAsync (JsonSerializer.SerializeToString(new {
				method = "answer",
				answer = Game.answers [pairId] [answerPos],
				result = result,
			}), null);

			this.Sessions.SendToAsync (id, JsonSerializer.SerializeToString(new {
				method = "answer",
				answer = answer,
				result = result,
			}), null);

			Game.answers [pairId] [2] = 0;
			Game.answers [pairId] [3] = 0;

			// finish game
			if (result > 0) {
				this.finishGame ();
				Game.results[pairId] = result;
			}
		}

		private String CreatePairId (String id1, String id2)
		{
			if (String.Compare(id1, id2) < 0) {
				return id1 + "|" + id2;
			} else {
				return id2 + "|" + id1;
			}
		}
	}
}

