using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec12 {
    internal class Puzzle {
        private string rawSpringStatuses;
        private List<int> springClusters;

        public Puzzle(string springStatuses, List<int> springClusters) {
            this.rawSpringStatuses = springStatuses;
            this.springClusters = springClusters;
        }

        public int NoOfPossibleArrangements() {
            return NoOfPossibleArrangementsRecursive(rawSpringStatuses);
        }

        public string Get() { return rawSpringStatuses; }

        public int NoOfPossibleArrangementsRecursive(string arrangement) {
            SearchValues<char> searchVal = SearchValues.Create("?");
            var index = arrangement.AsSpan().IndexOfAny(searchVal);//arrangement.IndexOf('?');
            if (index == -1) {
                //Console.WriteLine(arrangement);
                //No more arrangements to try
                if (IsLegit(arrangement)) {
                    return 1;
                }
                return 0;
            }
            var arrWithDot = Replace(arrangement, index, '.');
            var arrWithHash = Replace(arrangement, index, '#');
            return NoOfPossibleArrangementsRecursive(arrWithDot) + NoOfPossibleArrangementsRecursive(arrWithHash);
        }

        private bool IsLegit(string arrangement) {
            var splitArrangement = arrangement.Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();
            var arrangementClusters = splitArrangement.Select(arr => arr.Length).ToList();
            if (arrangementClusters.SequenceEqual(springClusters))
                return true;
            return false;
        }

        private string Replace(string s, int index, char replacement) {
            // Step 1: Convert the string to a char array
            char[] charArray = s.ToCharArray();

            // Step 2: Change the character at the desired index
            charArray[index] = replacement;

            // Step 3: Convert the char array back to a string
            return new string(charArray);
        }
        /*
         * ? == unknown
         * . == operational 
         * # == damaged 
         * */
        //private string ObviousArrangements() {
        //    var x = rawSpringStatuses.Split(".", StringSplitOptions.RemoveEmptyEntries);
        //    // Should now have a list of {"##", "??", "#?" }
        //    if (x.Length == springClusters.Count) {
        //        for(int clusterIndex = 0;  clusterIndex < springClusters.Count; clusterIndex++) {
        //            x[clusterIndex].
        //        }
        //    }
        //    return string.Join(".", x);
        //}
    }
}
