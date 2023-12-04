
namespace Dec2 {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello, World!");
			StreamReader sr = new StreamReader("input.txt");

			bool isPart1 = false;

			int gameId;
			int sum = 0;
			while (!sr.EndOfStream) {
				var line = sr.ReadLine() ?? "";
				var splitLine = line.Split(':');
				gameId = int.Parse(splitLine[0].Remove(0, 5));

				var games = splitLine[1].Split(';');
				Console.WriteLine($"GameId: {gameId}");

				if (isPart1) {
					if (IsOkGame(games)) {
						sum += gameId;
						Console.WriteLine($"Game {gameId} is ok!");
					}
				} else {
					int power = GetPower(games);
					sum += power;
					Console.WriteLine($"Game {gameId} has power {power}!");
				}
			}
			Console.WriteLine();
			Console.WriteLine(sum);
		}

		private static int GetPower(string[] games) {
			int minBlue = 0;
			int minGreen = 0;
			int minRed = 0;
			foreach (var game in games) {
				var colorInfos = game.Split(new char[] { ',', });
				foreach (var colorInfoString in colorInfos) {
					var x = colorInfoString.Trim().Split(' ');
					var number = int.Parse(x[0]);
					var color = x[1];

					if (color == "blue") {
						minBlue = Math.Max(minBlue, number);
					}
					if (color == "green") {
						minGreen = Math.Max(minGreen, number);
					}
					if (color == "red") {
						minRed = Math.Max(minRed, number);
					}
				}
			}
			int power = minBlue * minGreen * minRed;
			return power;
		}

		private static bool IsOkGame(string[] games) {
			int maxBlue = 14;
			int maxGreen = 13;
			int maxRed = 12;

			foreach (var game in games) {
				var colorInfos = game.Split(new char[] { ',', });
				foreach (var colorInfoString in colorInfos) {
					var x = colorInfoString.Trim().Split(' ');
					var number = int.Parse(x[0]);
					var color = x[1];

					if (color == "blue" && number > maxBlue) {
						return false;
					}
					if (color == "green" && number > maxGreen) {
						return false;
					}
					if (color == "red" && number > maxRed) {
						return false;
					}
					//Console.WriteLine($"{number} {color}");
				}
			}
			return true;
		}
	}
}
