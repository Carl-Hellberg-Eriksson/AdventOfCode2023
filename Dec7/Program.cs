using Shared;

namespace Dec7 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = FileHelper.ReadFileToStringList("input.txt");
            var hands = new List<Hand>();
            foreach (var line in lines) {
                var splitLine = line.Split(' ', StringSplitOptions.TrimEntries);
                hands.Add(new Hand(splitLine[0], int.Parse(splitLine[1])));
            }

            hands.Sort();
            var sum = 0;
            var index = 1;
            foreach (var hand in hands) {
                Console.WriteLine($"{hand.Cards()} :\t {hand.Type()} :\t {hand.HandStrength()}");
                sum += index * hand.Bet;
                index ++;
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
