using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec8 {
    internal class Node {
        public string Name;
        public string Left;
        public string Right;

        public Node(string name, string left, string right) { 
            Name = name;
            Left = left;
            Right = right;
        }
    }
}
