using System;
using System.Collections.Generic;

namespace Game.Store
{
	public class MemoryPlayers: IPlayers
	{
		private Dictionary<String, Model.Player> players = new Dictionary<String, Model.Player>();

		public MemoryPlayers ()
		{
		}

		public bool Add (Model.Player player)
		{
			this.players [player.id] = player;
			Console.WriteLine ("Add player. Players count: {0}", this.players.Count);
			return true;
		}

		public bool Del (String id)
		{
			this.players.Remove (id);
			Console.WriteLine ("Del player. Players count: {0}", this.players.Count);
			return true;
		}

		public Model.Player Get (String id)
		{
			Model.Player player;
			if (this.players.TryGetValue (id, out player)) {
				return player;
			} else {
				return null;
			}
		}

		public Dictionary<String, Model.Player> Get (Int32 limit, Int32 offset = 0)
		{
			return this.players;
		}
	}
}

