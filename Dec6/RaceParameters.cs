namespace Dec6 {
    public class RaceParameters {
        public long Time { get; set; }
        public long Distance { get; set; }
        public RaceParameters(long time, long distance) {
            Time = time;
            Distance = distance;
        }

        public long GetPart1Answer() {
            var sum = 0;
            for (var i = 0; i < Time; i++) {
                var possibleResult = (Time - i) * i;
                if (possibleResult > Distance) {
                    sum++;
                }
            }
            return sum;
        }
        public long GetPart2Answer() {
            long sum = 0;
            for (var i = 0; i < Time; i++) {
                var possibleResult = (Time - i) * i;
                if (possibleResult > Distance) {
                    sum++;
                }
            }
            return sum;
        }
    }
}
