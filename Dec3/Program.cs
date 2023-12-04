using Shared;

namespace Dec3 {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Hello, World!");
			var lines = FileHelper.ReadFileToStringList("input.txt");
			var width = lines[0].Length;
			lines.Insert(0, new string('.', width));
			Console.WriteLine(lines[0]);
			Console.WriteLine(lines[1]);
			lines.Insert(lines.Count(), new string('.', width));
			Console.WriteLine(lines.Last());
		}
	}
}
