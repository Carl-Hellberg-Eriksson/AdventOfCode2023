
using System.Text.RegularExpressions;

namespace Dec1 {
	internal class Program {

		static void Main(string[] args) {
			Console.WriteLine("Hello, World!");
			var regexF = GetRegexForward();
			var regexB = GetRegexBackwards();
			using StreamReader sr = new StreamReader("input.txt");
			int sum = 0;

			while (!sr.EndOfStream) {
				sum = sum + GetDoubleDigit(sr.ReadLine(), regexF, regexB);
			}

			Console.WriteLine();
			Console.WriteLine(sum);
		}

		private static string GetRegexForward() {
			List<string> stringNumbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
			List<string> intNumbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			string regexForward = "";

			foreach (var n in stringNumbers) {
				regexForward += n + "|";
			}
			foreach (var n in intNumbers) {
				regexForward += n + "|";
			}
			return regexForward.Remove(regexForward.Length - 1);
		}
		private static string GetRegexBackwards() {
			List<string> stringNumbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
			List<string> intNumbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			string regexForward = "";

			foreach (var n in stringNumbers) {
				regexForward += Reverse(n) + "|";
			}
			foreach (var n in intNumbers) {
				regexForward += n + "|";
			}
			return regexForward.Remove(regexForward.Length - 1);
		}

		private static int GetDoubleDigit(string? line, string regexF, string regexB) {
			var firstDigitString = Regex.Match(line, regexF).Value;
			var secondDigitString = Regex.Match(Reverse(line), regexB).Value;
			firstDigitString = Parse(firstDigitString).ToString();
			secondDigitString = Parse(Reverse(secondDigitString)).ToString();
			var number = Int32.Parse(firstDigitString + Reverse(secondDigitString));

			Console.WriteLine($"Found {firstDigitString} and {secondDigitString}, which gives {number}. From {line}");

			return number;
		}

		private static string Reverse(string s) {
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		private static int Parse(string s) {
			if (Int32.TryParse(s, out var number)) {
				return number;
			}
			switch (s) {
				case "one": return 1;
				case "two": return 2;
				case "three": return 3;
				case "four": return 4;
				case "five": return 5;
				case "six": return 6;
				case "seven": return 7;
				case "eight": return 8;
				case "nine": return 9;
			}
			throw new Exception("unexpected character " + s);
		}
	}
}
