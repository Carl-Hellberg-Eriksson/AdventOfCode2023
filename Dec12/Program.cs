namespace Dec12 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = File.ReadAllLines("input.txt");
            //var lines = File.ReadAllLines("sampleInput.txt");
            List<Puzzle> puzzles = new List<Puzzle>();
            foreach (var line in lines) {
                var splitLine = line.Split(" ");
                puzzles.Add(new Puzzle(splitLine[0], splitLine[1].Split(',').Select(x => int.Parse(x)).ToList()));
            }
            var sum = 0;
            foreach (var puzzle in puzzles) {
                Console.WriteLine(puzzle.Get());
                sum += puzzle.NoOfPossibleArrangements();
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
