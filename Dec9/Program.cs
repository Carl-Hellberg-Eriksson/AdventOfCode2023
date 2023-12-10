namespace Dec9 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = File.ReadAllLines("input.txt");
            //var lines = File.ReadAllLines("SampleInput.txt");
            List<HistoryLine> history = new List<HistoryLine>();
            foreach (var line in lines) {
                var splitLine = line.Split(' ', StringSplitOptions.TrimEntries).ToList();
                history.Add(new HistoryLine(splitLine.Select(x => int.Parse(x)).ToList()));
            }

            Console.WriteLine();
            var sum = 0;
            foreach(var his in history) {
                PrintList(his.Values);
                //Console.WriteLine(his.GetAnswer());

                //sum += his.GetAnswerPart1();
                sum -= his.GetAnswerPart2();
            //    PrintList(his.GetUnderLyingValues(his.Values));
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
        static void PrintList(List<int> line) {
            foreach(int number in line) {
                Console.Write(number);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
