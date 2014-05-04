using System;
using WebSocketSharp.Server;

namespace Game
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var wssv = new WebSocketServer(8080);
			wssv.AddWebSocketService<Game>("/game");
			wssv.Start();
			Console.ReadKey(true);
			wssv.Stop();
		}
	}
}
