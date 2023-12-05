using Shared;

namespace Dec5 {
    internal class Program {
        static void Main(string[] args) {
            var lines = FileHelper.ReadFileToStringList("input.txt");

            var seeds = lines.First().Split(':', StringSplitOptions.TrimEntries)[1].Split(' ', StringSplitOptions.TrimEntries).ToList().Select(s => long.Parse(s)).ToList();
            var seedsCount = seeds.Count();

            lines.RemoveAt(0); // Remove seed-row
            lines.RemoveAt(0); // Remove first blank row.
            var maps = new List<Map>();

            Map map = new Map();
            foreach (var line in lines) {
                if (string.IsNullOrEmpty(line)) {
                    maps.Add(map);
                    map = new Map();
                } else if (!int.TryParse(line[0].ToString(), out _)) {
                    map.description = line;
                } else {
                    var splitLine = line.Split(' ', StringSplitOptions.TrimEntries);
                    map.ranges.Add(new Range(long.Parse(splitLine[0]), long.Parse(splitLine[1]), long.Parse(splitLine[2])));
                }
            }
            maps.Add(map);

            var lowestSeedValue = long.MaxValue;
            foreach(var seed in seeds) {
                var seedValue = seed;
                foreach(var m in maps) {
                    Console.WriteLine($"Original seed {seed}");
                    seedValue = m.ConvertSeed(seedValue);
                    Console.WriteLine($"{m.description} Converted to {seedValue} ");
                }
                lowestSeedValue = long.Min(lowestSeedValue, seedValue);
            }

            Console.WriteLine();
            Console.WriteLine(lowestSeedValue);
        }
    }
}
