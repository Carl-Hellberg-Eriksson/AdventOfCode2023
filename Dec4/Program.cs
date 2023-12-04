using Shared;

namespace Dec4 {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello, World!");
			//var totalPoints = 0;
			var lines = FileHelper.ReadFileToStringList("input.txt");
			var cards = new List<LotteryCard>();

			foreach (var line in lines) {
				var splitLine = line.Split(':');
				var cardIdPart = splitLine[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				var gameId = int.Parse(cardIdPart[1]);
				var winningNumbers = splitLine[1].Split('|')[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
				var ourNumbers = splitLine[1].Split('|')[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

				cards.Add(new LotteryCard(gameId, winningNumbers.Select(x => int.Parse(x)).ToList(), ourNumbers.Select(x => int.Parse(x)).ToList()));
			}

			var gameQueue = new List<LotteryCard>(cards);

			//Started this faster way but got interrupted by the execution of the way below actually finnishing with 13261850 cards :)
			//gameQueue.Reverse();

			//foreach(var card in gameQueue) {
			//	var numberOfWins = card.GetNumberOfWinningNumbers();
			//	if (numberOfWins == 0) {
			//		card.totalWinningTickets = numberOfWins;
			//	} else {
			//		var sum = cards.Where(c => c.cardId > card.cardId && c.cardId <= card.cardId + numberOfWins).ToList()
			//			.Select(c => c.totalWinningTickets)
			//			.Sum();
			//		card.totalWinningTickets = sum;
			//	}
			//}

			//foreach (var card in gameQueue) {
			for (int i = 0; i < gameQueue.Count; i++) {
				var card = gameQueue[i];
				var numberOfWins = card.GetNumberOfWinningNumbers();
				gameQueue.AddRange(cards.Where(c => c.cardId > card.cardId && c.cardId <= card.cardId + numberOfWins).ToList());
				Console.WriteLine($"{card.cardId} has {numberOfWins} wins: adding games {card.cardId + 1} .. {card.cardId + numberOfWins} to the pool");
			}
			Console.WriteLine();
			Console.WriteLine(gameQueue.Count);
			//lines = lines.Select(line => line.Split(':')[1].Trim()).ToList(); // Remove the "Card x:"
			//																  //Console.WriteLine(lines[0]);
			//foreach (var line in lines) {
			//	var winningNumbers = line.Split('|')[0].Trim().Split(' ').ToList();
			//	winningNumbers = winningNumbers.Distinct().ToList();
			//	winningNumbers.Remove(""); // Remove empties that occur because of single digit numbers.

			//	var ourNumbers = line.Split('|')[1].Trim().Split(' ').ToList();
			//	ourNumbers = ourNumbers.Distinct().ToList();
			//	ourNumbers.Remove(""); // Remove empties that occur because of single digit numbers.

			//	var linePoints = 0;
			//	foreach (var number in ourNumbers) {
			//		if (winningNumbers.Contains(number)) {
			//			linePoints = linePoints * 2;
			//			if (linePoints == 0) { linePoints = 1; }
			//			Console.WriteLine($"{number} is matched, new linepoint: {linePoints}");
			//		}
			//	}
			//	totalPoints = totalPoints + linePoints;
			//}
			//Console.WriteLine();
			//Console.WriteLine(totalPoints);
		}
	}
}

