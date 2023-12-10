using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec9 {
    internal class HistoryLine {
        List<int> values = new List<int>();

        public HistoryLine(List<int> values) {
            this.values = values;
        }

        public List<int> Values { get {  return values; } }

        public List<int> GetUnderLyingValues(List<int> values) {
            var returnValue = new List<int>();
            for(int i = 0; i < values.Count - 1; i++) {
                returnValue.Add(values[i+1] - values[i]);
            }
            return returnValue;
        }

        public int GetAnswerPart1() {
            return values.Last() + GetNextValue(this.values);
        }
        private int GetNextValue(List<int> values) {
            var nextValues = new List<int>();
            for (int i = 0; i < values.Count - 1; i++) {
                nextValues.Add(values[i + 1] - values[i]);
            }
            if (nextValues.All(x => x == 0)) {
                return 0;
            }

            return nextValues.Last() + GetNextValue(nextValues);
        }

        public int GetAnswerPart2() {
            return values.First() - GetPrevValue(this.values);
        }
        private int GetPrevValue(List<int> values) {
            var nextValues = new List<int>();
            for (int i = 0; i < values.Count - 1; i++) {
                nextValues.Add(values[i + 1] - values[i]);
            }
            if (nextValues.All(x => x == 0)) {
                return 0;
            }

            return nextValues.First() - GetPrevValue(nextValues);
        }
    }
}
