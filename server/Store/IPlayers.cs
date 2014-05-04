using System;
using System.Collections.Generic;

namespace Game.Store
{
	public interface IPlayers
	{
		bool Add (Model.Player player);
		bool Del (String id);
		Model.Player Get (String id);
		Dictionary<String, Model.Player> Get (Int32 limit, Int32 offset = 0);
	}
}

