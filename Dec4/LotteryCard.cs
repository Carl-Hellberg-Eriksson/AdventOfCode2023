namespace Dec4 {
	internal class LotteryCard {
		public int cardId;
		public List<int> winningNumbers;
		public List<int> playerNumbers;
		public int totalWinningTickets;

		public LotteryCard(int cardId, List<int> winningNumbers, List<int> playerNumbers) {
			this.cardId = cardId;
			this.winningNumbers = winningNumbers;
			this.playerNumbers = playerNumbers;
		}

		public int GetNumberOfWinningNumbers() {
			var x = winningNumbers.Intersect(playerNumbers);
			return x.Count();
		}
	}
}
