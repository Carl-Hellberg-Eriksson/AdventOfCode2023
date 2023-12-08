namespace Dec8 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = File.ReadAllLines("input.txt").ToList();
            var LeftRightInstructions = lines[0];

            //Remove LeftRight and empty row.
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            var nodes = new List<Node>();
            foreach(var line in lines) {
                nodes.Add(new Node(line.Substring(0, 3), line.Substring(7, 3), line.Substring(12, 3)));
            }

            var currentPos = "AAA";
            var instructionIndex = 0;
            var steps = 0;
            while (currentPos != "ZZZ") {
                var currentNode = nodes.Where(node => node.Name == currentPos).FirstOrDefault();
                if (currentNode == null) throw new Exception("WTFWTF");

                var nextInstruction = LeftRightInstructions[instructionIndex];

                if (nextInstruction == 'L') {
                    currentPos = currentNode.Left;
                } else if (nextInstruction == 'R') {
                    currentPos = currentNode.Right;
                } else {
                    throw new Exception("WTF");
                }

                steps++;
                instructionIndex++;
                if (instructionIndex == LeftRightInstructions.Length) instructionIndex = 0;
            }
            Console.WriteLine();
            Console.WriteLine(steps);
        }
    }
}
