using System.Text.RegularExpressions;

namespace Dec10 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            //var lines = File.ReadAllLines("sampleImput.txt");
            var lines = File.ReadAllLines("input.txt");
            var StartingRowId = 0;
            var StartingColId = 0;
            foreach (var line in lines) {
                var match = Regex.Match(line, "S");
                if (match.Success) {
                    StartingColId = match.Index;
                    break;
                }
                StartingRowId++;
            }
            var maxRowId = lines.Length - 1;
            var maxColId = lines[0].Length - 1;
            (int RowId, int ColId) prevPosition = (StartingRowId, StartingColId);
            (int RowId, int ColId) nextPosition = (-1, -1);
            Console.WriteLine(lines[StartingRowId - 1].Substring(StartingColId - 1, 3));
            Console.WriteLine(lines[StartingRowId].Substring(StartingColId - 1, 3));
            Console.WriteLine(lines[StartingRowId + 1].Substring(StartingColId - 1, 3));
            var circularPath = new List<(int RowId, int ColId)>();

            foreach (var surrCord in SurroundingCoordinates((StartingRowId, StartingColId), maxRowId, maxColId)) {
                var character = lines[surrCord.RowId][surrCord.ColId];
                var connCord = ConnectedCoordinates(surrCord, lines[surrCord.RowId][surrCord.ColId], maxRowId, maxColId);
                foreach (var cn in connCord) {
                    var char2 = lines[cn.RowId][cn.ColId];
                }
                if (connCord.Any(x => lines[x.RowId][x.ColId] == 'S')) {
                    nextPosition = surrCord;
                }
            }

            var sum = 0;
            while (lines[nextPosition.RowId][nextPosition.ColId] != 'S') {
                circularPath.Add(nextPosition);
                //PrintWithHighlight(lines, circularPath);

                var nextnext = ConnectedCoordinates(nextPosition, lines[nextPosition.RowId][nextPosition.ColId], maxRowId, maxColId)
                    .Where(x => x != prevPosition).First();
                prevPosition = nextPosition;
                nextPosition = nextnext;

                sum++;
            }
            Console.WriteLine(sum);
        }

        private static void PrintWithHighlight(string[] lines, List<(int rowId, int colId)> co) {
            var currentRowId = 0;

            Console.Clear();
            foreach (var line in lines) {
                for (var colId = 0; colId < line.Length; colId++)
                    if (co.Any(x => x.rowId == currentRowId && x.colId == colId)) {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(line[colId]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    } else {
                        Console.Write(line[colId]);
                    }
                Console.WriteLine();
            }
            Console.WriteLine();
            currentRowId++;
        }
        private static IEnumerable<(int RowId, int ColId)> SurroundingCoordinates((int RowId, int ColId) co, int maxRowId, int maxColId) {
            var returnList = new List<(int RowId, int ColId)>();
            returnList.Add((co.RowId, co.ColId + 1));
            returnList.Add((co.RowId, co.ColId - 1));
            returnList.Add((co.RowId - 1, co.ColId));
            returnList.Add((co.RowId - 1, co.ColId));
            return returnList.Where(x => x.RowId >= 0 && x.RowId <= maxRowId && co.ColId >= 0 && co.ColId <= maxColId);
        }

        private static IEnumerable<(int RowId, int ColId)> ConnectedCoordinates((int RowId, int ColId) co, char pipe, int maxRowId, int maxColId) {
            var returnList = new List<(int RowId, int ColId)>();
            switch (pipe) {
                /*
                | is a vertical pipe connecting north and south.
                - is a horizontal pipe connecting east and west.
                L is a 90-degree bend connecting north and east.
                J is a 90-degree bend connecting north and west.
                7 is a 90-degree bend connecting south and west.
                F is a 90-degree bend connecting south and east.
                . is ground; there is no pipe in this tile.
                S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
            */
                case '|': {
                        returnList.Add((co.RowId + 1, co.ColId));
                        returnList.Add((co.RowId - 1, co.ColId));
                        break;
                    }
                case '-': {
                        returnList.Add((co.RowId, co.ColId - 1));
                        returnList.Add((co.RowId, co.ColId + 1));
                        break;
                    }
                case 'L': {
                        returnList.Add((co.RowId + 1, co.ColId));
                        returnList.Add((co.RowId, co.ColId + 1));
                        break;
                    }
                case 'J': {
                        returnList.Add((co.RowId + 1, co.ColId));
                        returnList.Add((co.RowId, co.ColId - 1));
                        break;
                    }
                case '7': {
                        returnList.Add((co.RowId, co.ColId - 1));
                        returnList.Add((co.RowId - 1, co.ColId));
                        break;
                    }
                case 'F': {
                        returnList.Add((co.RowId, co.ColId + 1));
                        returnList.Add((co.RowId - 1, co.ColId));
                        break;
                    }
                case '.': {
                        break;
                    }
                case 'S': {
                        returnList.Add((co.RowId + 1, co.ColId));
                        returnList.Add((co.RowId - 1, co.ColId));
                        returnList.Add((co.RowId, co.ColId + 1));
                        returnList.Add((co.RowId, co.ColId - 1));
                        break;
                    }
                default: {
                        throw new Exception("WTF");
                    }
            }
            return returnList.Where(x => x.RowId >= 0 && x.RowId <= maxRowId && x.ColId >= 0 && x.ColId <= maxColId);
        }
    }
}
