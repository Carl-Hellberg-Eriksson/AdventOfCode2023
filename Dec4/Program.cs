using Shared;

namespace Dec4 {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello, World!");
			var totalPoints = 0;
			var lines = FileHelper.ReadFileToStringList("input.txt");
			lines = lines.Select(line => line.Split(':')[1].Trim()).ToList(); // Remove the "Card x:"
																			  //Console.WriteLine(lines[0]);
			foreach (var line in lines) {
				var winningNumbers = line.Split('|')[0].Trim().Split(' ').ToList();
				winningNumbers = winningNumbers.Distinct().ToList();
				winningNumbers.Remove(""); // Remove empties that occur because of single digit numbers.

				var ourNumbers = line.Split('|')[1].Trim().Split(' ').ToList();
				ourNumbers = ourNumbers.Distinct().ToList();
				ourNumbers.Remove(""); // Remove empties that occur because of single digit numbers.

				var linePoints = 0;
				foreach (var number in ourNumbers) {
					if (winningNumbers.Contains(number)) {
						linePoints = linePoints * 2;
						if (linePoints == 0) { linePoints = 1; }
						Console.WriteLine($"{number} is matched, new linepoint: {linePoints}");
					}
				}
				totalPoints = totalPoints + linePoints;
			}
			Console.WriteLine();
			Console.WriteLine(totalPoints);
		}
	}
}

