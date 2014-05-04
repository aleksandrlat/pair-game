using System;
using System.Collections.Generic;

namespace Game.Model
{
	public class Player
	{
		public enum Gender { female, male };

		public String id;
		public String name;
		public Gender gender;
		public Pair pair;
		public Dictionary<String, Player> invites = new Dictionary<String, Player>(10);

		public Player Opponent
		{
			get {
				if (this.pair == null) {
					return null;
				}
				if (this.pair.player1.id == this.id) {
					return this.pair.player2;
				} else {
					return this.pair.player1;
				}
			}
		}
	}
}

