using Shared;

namespace Dec6 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = FileHelper.ReadFileToStringList("input.txt");

            var race = new RaceParameters(48876981, 255128811171623);
            //var splitlines = lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            //var races = new List<RaceParameters>();
            //for(int i = 1; i < splitlines.First().Count(); i++) {
            //    races.Add(new RaceParameters(int.Parse(splitlines.First()[i]), int.Parse(splitlines.Last()[i])));
            //}

            //var product = 1;
            //foreach(var race in races) {
            //    product *= race.GetPart1Answer();
            //}

            Console.WriteLine();
            Console.WriteLine(race.GetPart2Answer());
        }
    }
}
