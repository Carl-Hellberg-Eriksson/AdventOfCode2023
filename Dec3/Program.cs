using Shared;

namespace Dec3 {
	internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = FileHelper.ReadFileToStringList("input.txt");
            
            //Rama in inputen med punkter för att slippa tänka på edge cases.
            var width = lines[0].Length;
            lines.Insert(0, new string('.', width));
            lines.Insert(lines.Count(), new string('.', width));
            lines = lines.Select(line => "." + line + ".").ToList();

            int sum = 0;
            var rowId = 0;
            var colId = 0;
            var gears = new List<Gear>();
            foreach (var line in lines) {
                foreach (var character in line) {
                    if (character == '*') {
                        sum += GetGearRatio(rowId, colId, lines);
                    }
                    colId++;
                }
                colId = 0;
                rowId++;
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }

        private static int GetGearRatio(int rowId, int colId, List<string> lines) {
            var toprow = lines[rowId-1].Substring(colId - 1, 3);
            var leftSide = lines[rowId].Substring(colId - 1, 1);
            var rightSide = lines[rowId].Substring(colId + 1, 1);
            var bottomRow = lines[rowId+1].Substring(colId - 1, 3);
            var adjecentInts = new List<int>();

            if (int.TryParse(leftSide, out _)) {
                adjecentInts.Add(GetIntAtCoordinate(lines[rowId], colId - 1, (rowId, colId)));
            }
            if (int.TryParse(rightSide, out _)) {
                adjecentInts.Add(GetIntAtCoordinate(lines[rowId], colId + 1, (rowId, colId)));
            }
            if (int.TryParse(toprow, out _)) {
                adjecentInts.Add(GetIntAtCoordinate(lines[rowId - 1], colId, (rowId, colId)));
            }
            if (int.TryParse(bottomRow, out _)) {
                adjecentInts.Add(GetIntAtCoordinate(lines[rowId + 1], colId, (rowId, colId)));
            }

            if (!int.TryParse(toprow[1].ToString(), out _)) {
                if (int.TryParse(toprow[0].ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId - 1], colId - 1, (rowId, colId)));
                }
                if (int.TryParse(toprow[2].ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId - 1], colId + 1, (rowId, colId)));
                }
            }
            if (!int.TryParse(toprow[2].ToString(), out _)) {
                if (int.TryParse(toprow.Substring(0, 2).ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId - 1], colId - 1, (rowId, colId)));
                }
            }
            if (!int.TryParse(toprow[0].ToString(), out _)) {
                if (int.TryParse(toprow.Substring(1, 2).ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId - 1], colId + 1, (rowId, colId)));
                }
            }

            if (!int.TryParse(bottomRow[1].ToString(), out _)) {
                if (int.TryParse(bottomRow[0].ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId + 1], colId - 1, (rowId, colId)));
                }
                if (int.TryParse(bottomRow[2].ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId + 1], colId + 1, (rowId, colId)));
                }
            }
            if (!int.TryParse(bottomRow[2].ToString(), out _)) {
                if (int.TryParse(bottomRow.Substring(0, 2).ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId + 1], colId - 1, (rowId, colId)));
                }
            }
            if (!int.TryParse(bottomRow[0].ToString(), out _)) {
                if (int.TryParse(bottomRow.Substring(1, 2).ToString(), out _)) {
                    adjecentInts.Add(GetIntAtCoordinate(lines[rowId + 1], colId + 1, (rowId, colId)));
                }
            }


            if (adjecentInts.Count == 2) { 
                return adjecentInts.First() * adjecentInts.Last(); 
            }
            return 0;

        }

        private static int GetIntAtCoordinate(string line, int colId, (int x, int y) debug){
            var backWardsCount = colId-1;
            var maxLength = line.Length;
            List<char> number = new List<char>();
            while (colId >= 0 && colId < maxLength && int.TryParse(line[colId].ToString(), out _)) {
                number.Add(line[colId]);
                colId++;
            }
            while (backWardsCount >= 0 && backWardsCount < maxLength && int.TryParse(line[backWardsCount].ToString(), out _)) {
                number.Insert(0, line[backWardsCount]);
                backWardsCount--;
            }
            return int.Parse(new string(number.ToArray()));
        }

        //List<char> numbersNdot = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
        //Console.WriteLine("Hello, World!");
        //var lines = FileHelper.ReadFileToStringList("input.txt");
        //var width = lines[0].Length;
        //lines.Insert(0, new string('.', width));
        //Console.WriteLine(lines[0]);
        //Console.WriteLine(lines[1]);
        //lines.Insert(lines.Count(), new string('.', width));
        //lines = lines.Select(line => "." + line + ".").ToList();
        //Console.WriteLine(lines[4]);
        //int sum = 0;
        //for (int row = 0; row < lines.Count; row++) {
        //	var line = lines[row];
        //	string numberString = "";
        //	bool isAdjecentToThingie = false;

        //	for (int charIndex = 0; charIndex < line.Length; charIndex++) {
        //		var character = line[charIndex];
        //		if (int.TryParse(character.ToString(), out _)) {
        //			numberString += character;
        //			if (!numbersNdot.Contains(lines[row][charIndex + 1]) |
        //				!numbersNdot.Contains(lines[row][charIndex + -1]) |
        //				!numbersNdot.Contains(lines[row - 1][charIndex + 1]) |
        //				!numbersNdot.Contains(lines[row - 1][charIndex]) |
        //				!numbersNdot.Contains(lines[row - 1][charIndex - 1]) |
        //				!numbersNdot.Contains(lines[row + 1][charIndex + 1]) |
        //				!numbersNdot.Contains(lines[row + 1][charIndex]) |
        //				!numbersNdot.Contains(lines[row + 1][charIndex - 1])
        //				) {
        //				isAdjecentToThingie = true;
        //			}
        //		} else if (!string.IsNullOrEmpty(numberString)) {
        //			Console.WriteLine($"Found {numberString} in line: {line}");
        //			if (isAdjecentToThingie) {
        //				sum += int.Parse(numberString);
        //				isAdjecentToThingie = false;
        //			}
        //			numberString = "";
        //		}
        //	}
        //}

        //Console.WriteLine();
        //Console.WriteLine(sum);
    //}

    }
}
