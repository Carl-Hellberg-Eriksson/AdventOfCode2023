using Shared;

namespace Dec3 {
	internal class Program {
		static void Main(string[] args) {
			List<char> numbersNdot = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
			Console.WriteLine("Hello, World!");
			var lines = FileHelper.ReadFileToStringList("input.txt");
			var width = lines[0].Length;
			lines.Insert(0, new string('.', width));
			Console.WriteLine(lines[0]);
			Console.WriteLine(lines[1]);
			lines.Insert(lines.Count(), new string('.', width));
			lines = lines.Select(line => "." + line + ".").ToList();
			Console.WriteLine(lines[4]);
			int sum = 0;
			for (int row = 0; row < lines.Count; row++) {
				var line = lines[row];
				string numberString = "";
				bool isAdjecentToThingie = false;

				for (int charIndex = 0; charIndex < line.Length; charIndex++) {
					var character = line[charIndex];
					if (int.TryParse(character.ToString(), out _)) {
						numberString += character;
						if (!numbersNdot.Contains(lines[row][charIndex + 1]) |
							!numbersNdot.Contains(lines[row][charIndex + -1]) |
							!numbersNdot.Contains(lines[row - 1][charIndex + 1]) |
							!numbersNdot.Contains(lines[row - 1][charIndex]) |
							!numbersNdot.Contains(lines[row - 1][charIndex - 1]) |
							!numbersNdot.Contains(lines[row + 1][charIndex + 1]) |
							!numbersNdot.Contains(lines[row + 1][charIndex]) |
							!numbersNdot.Contains(lines[row + 1][charIndex - 1])
							) {
							isAdjecentToThingie = true;
						}
					} else if (!string.IsNullOrEmpty(numberString)) {
						Console.WriteLine($"Found {numberString} in line: {line}");
						if (isAdjecentToThingie) {
							sum += int.Parse(numberString);
							isAdjecentToThingie = false;
						}
						numberString = "";
					}
				}
			}

			Console.WriteLine();
			Console.WriteLine(sum);
		}
	}
}
