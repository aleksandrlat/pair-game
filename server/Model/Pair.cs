using System;

namespace Game.Model
{
	public class Pair
	{
		public Player player1;
		public Player player2;

		public String Id
		{
			get {
				if (String.Compare(this.player1.id, this.player2.id) < 0) {
					return this.player1.id + "|" + this.player2.id;
				} else {
					return this.player2.id + "|" + this.player1.id;
				}
			}
		}
	}
}

