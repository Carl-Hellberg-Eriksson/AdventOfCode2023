using Shared;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Dec11 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            //var lines = File.ReadAllLines("sampleInput.txt").ToList();
            var lines = File.ReadAllLines("input.txt").ToList();
            var extraLine = new string('.', lines[0].Length);

            //Expand universe
            //First by length
            for(int rowId = 0; rowId < lines.Count(); rowId++) {
                if (lines[rowId].All(x => x == '.')) {
                    lines.Insert(rowId, extraLine);
                    rowId++;
                }
            }
            //Then by Width
            for(int colId = 0; colId < lines[0].Length; colId++) {
                if (lines.All(line => line[colId] == '.')) {
                    lines = lines.Select(line => line = line.Insert(colId, ".")).ToList();
                    colId++;
                }
            }

            foreach(var line in lines) {
                Console.WriteLine($"{line}");
            }

            List<Coordinate> galaxies = new List<Coordinate>();
            var sumDistance = 0;
            for (int rowId = 0; rowId < lines.Count(); rowId++) {
                var galaxyMatches = Regex.Matches(lines[rowId], "#");
                foreach (var galaxyMatch in galaxyMatches.Where(x => x.Success)) {
                    foreach(var galaxy in galaxies) {
                        var distance = Math.Abs(galaxy.rowId - rowId) + Math.Abs(galaxy.colId - galaxyMatch.Index);
                        sumDistance += distance;
                    }
                    galaxies.Add(new Coordinate(rowId, galaxyMatch.Index));
                }
            }

            Console.WriteLine();
            Console.WriteLine(sumDistance);
        }
    }
}
