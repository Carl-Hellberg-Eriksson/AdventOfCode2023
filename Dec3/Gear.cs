using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec3 {
    internal class Gear {
        public int Row {  get; set; }
        public int Column { get; set; }

        public Gear(int row, int col) {
            this.Row = row;
            this.Column = col;
        }
    }
}
