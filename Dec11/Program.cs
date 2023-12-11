using System.Text.RegularExpressions;
using Shared;

namespace Dec11 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            long EXTRADISTANCE = 1000000 - 1;
            //var lines = File.ReadAllLines("sampleInput.txt").ToList();
            var lines = File.ReadAllLines("input.txt").ToList();
            var extraLine = new string('.', lines[0].Length);

            //Expand universe
            //First by length
            var expandedRows = new List<int>();
            var expandedCols = new List<int>();
            for (var rowId = 0; rowId < lines.Count(); rowId++) {
                if (lines[rowId].All(x => x == '.')) {
                    expandedRows.Add(rowId);
                }
            }
            //Then by Width
            for (var colId = 0; colId < lines[0].Length; colId++) {
                if (lines.All(line => line[colId] == '.')) {
                    expandedCols.Add(colId);
                }
            }

            for(int rowId = 0; rowId < lines.Count; rowId++) {
                for (int colId = 0; colId < lines[0].Length; colId++) {
                    if (expandedCols.Any(x => x == colId) || expandedRows.Any(x => x == rowId)) {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(lines[rowId][colId]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    } else {
                        Console.Write(lines[rowId][colId]);
                    }
                }
                Console.WriteLine();
            }

            var galaxies = new List<Coordinate>();
            long sumDistance = 0;
            for (var rowId = 0; rowId < lines.Count(); rowId++) {
                var galaxyMatches = Regex.Matches(lines[rowId], "#");
                foreach (var galaxyMatch in galaxyMatches.Where(x => x.Success)) {
                    foreach (var galaxy in galaxies) {
                        var distance = Math.Abs(galaxy.rowId - rowId) + Math.Abs(galaxy.colId - galaxyMatch.Index);

                        //Stupid way: :)
                        //var noOfOverlappingExpandingRows = expandedRows.Where(rowNumber => IsXBetweenY1AndY2(rowNumber, galaxy.rowId, rowId)).Count();
                        //var noOfOverlappingExpandingCols = expandedCols.Where(colNumber => IsXBetweenY1AndY2(colNumber, galaxy.colId, galaxyMatch.Index)).Count();
                        //distance += EXTRADISTANCE * noOfOverlappingExpandingRows;
                        //distance += EXTRADISTANCE * noOfOverlappingExpandingCols;
                        
                        sumDistance += distance;
                    }
                    galaxies.Add(new Coordinate(rowId, galaxyMatch.Index));
                    Console.WriteLine($"({rowId}, {galaxyMatch.Index}) ");
                }
            }

            foreach(var row in expandedRows) {
                long countSmaller = galaxies.Where(galaxy => galaxy.rowId < row).Count();
                long countBigger = galaxies.Where(galaxy => galaxy.rowId > row).Count();
                sumDistance += countSmaller * countBigger * EXTRADISTANCE;
            }

            foreach (var col in expandedCols) {
                long countSmaller = galaxies.Where(galaxy => galaxy.colId < col).Count();
                long countBigger = galaxies.Where(galaxy => galaxy.colId > col).Count();
                sumDistance += countSmaller * countBigger * EXTRADISTANCE;
            }

            Console.WriteLine();
            Console.WriteLine(sumDistance);
        }
        public static bool IsXBetweenY1AndY2(int x, int y1, int y2) {
            return (x > Math.Min(y1, y2)) && (x < Math.Max(y1, y2));
        }
    }
}
