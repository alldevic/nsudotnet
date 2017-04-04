using System;

namespace Belyi.Nsudotnet.NumberGuesser
{
	class MainClass
	{
		static readonly string prefix = "> ";


		public static void Main(string[] args)
		{
			var cmd = String.Empty;
			while (String.IsNullOrWhiteSpace(cmd))
			{
				Console.WriteLine("My name is NumberGuesser; what's your name?");
				Console.Write(prefix);
				cmd = Console.ReadLine();
			}
			var game = new Game(cmd);
			game.Begin();

			while (!String.Equals(cmd = Console.ReadLine(), "q"))
			{
				game.GameStep(cmd);
			}
			game.End();
			game.PrintStat();
			Console.WriteLine(String.Format("Goodbye, {0}!", game.playerName));
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
			return;
		}

	}

	class Game
	{
		static readonly string[] insults = {
			"SGEtaGEsIGxvbA==", "QnV0dHNhdWNlIQ==", "SSBhbSBUaGUgTGF3",
			"WW91IHByb2JhYmx5IHRob3VnaHQgeW91IHdlcmVuJ3QgZ29ubmEgZ3Vlc3MgbnVtYmVyIHRvZGF5PyBTdXJwcmlzZSE=",
			"WW91IGNhbid0IGd1ZXNzIG51bWJlcnMsIEkgY2FuIQ==", "WW91IHByb2JhYmx5IHRoaW5rIEknbSBhIG5pY2UgZ2FtZS4uLg==",
			"VG9kYXkncyB0aGUgZmlyc3QgZGF5IG9mIHRoZSBlbmQgb2YgeW91ciBsaXZlLg==",
			"SSBrbm93IHdoYXQgeW91J3JlIHRoaW5raW5nLCBidXQgdGhlIGZ1bm55IHRoaW5nIGlzLCBJIGRvbid0IGV2ZW4gTElLRSBudW1iZXJzLi4u",
			"VGhpbmcgaXMsIEkgZG9uJ3QgZXZlbiBsaWtlIHRoaXMgbnVtYmVyIGxpa2UgYXMgeW91Lg==",
			"WWVhaCwgeWVhaCwgYmxhaCwgYmxhaCwganVzdCB0cnkgdG8gZ3Vlc3MgbnVtYmVyIGFscmVhZHksIGJpZyBtYW4h",
			};

		private int count;
		private int[] history = new int[1000];

		public string playerName { get; }

		public Game(string name)
		{
			playerName = name;
		}

		public void Begin()
		{
			Console.WriteLine(string.Format("Hello, {0}!", playerName));
		}

		public void End()
		{

		}

		public void GameStep(string cmd)
		{
			count++;
			var k = new Random().Next(0, insults.Length - 1);
			var bytes = Convert.FromBase64String(insults[k]);
			Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
		}

		public void PrintStat()
		{

		}
	}

}