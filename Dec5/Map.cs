using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec5 {
    public class Map {
        public string? description { get; set; }
        public List<Range> ranges { get; set; }

        public Map() {
            this.ranges = new List<Range>();
        }

        public long ConvertSeed(long seed) {
            foreach (Range range in ranges) {
                if (seed >= range.sourceRangeStart && seed <= range.sourceRangeEnd) {
                    return seed + range.increaseBy;
                }
            }
            return seed;
        }
    }
}
