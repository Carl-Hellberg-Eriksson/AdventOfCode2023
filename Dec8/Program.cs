using System.Runtime.InteropServices;

namespace Dec8 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var lines = File.ReadAllLines("input.txt").ToList();
            //var lines = File.ReadAllLines("SampleInput.txt").ToList();
            var LeftRightInstructions = lines[0];

            //Remove LeftRight and empty row.
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            var nodes = new List<Node>();
            foreach(var line in lines) {
                nodes.Add(new Node(line.Substring(0, 3), line.Substring(7, 3), line.Substring(12, 3)));
            }

            var currentNodes = nodes.Where(node => node.Name[2] == 'A');
            //var currentNodes = new List<Node>();
            var instructionIndex = 0;
            var steps = 0;
            while (currentNodes.Any(node => node.Name[2] != 'Z')) {
                Print(currentNodes);
                var nextInstruction = LeftRightInstructions[instructionIndex];
                Console.WriteLine(nextInstruction);
                var nextNodes = new List<Node>();
                if (nextInstruction == 'L') {
                    foreach(var node in currentNodes) {
                        nextNodes.Add(nodes.Where(n => n.Name == node.Left).First());
                    }
                } else if (nextInstruction == 'R') {
                    foreach (var node in currentNodes) {
                        nextNodes.Add(nodes.Where(n => n.Name == node.Right).First());
                    }
                } else {
                    throw new Exception("WTF");
                }
                currentNodes = nextNodes;
                steps++;
                instructionIndex++;
                if (instructionIndex == LeftRightInstructions.Length) instructionIndex = 0;
            }
            Console.WriteLine();
            Console.WriteLine(steps);
        }

        private static void Print(IEnumerable<Node> currentNodes) {
            foreach (var node in currentNodes) {
                Console.Write($"{node.Name}({node.Left},{node.Right}) ");
            }
            Console.WriteLine();
        }
    }
}
