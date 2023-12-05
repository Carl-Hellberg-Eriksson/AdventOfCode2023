namespace Dec5 {
    public class Range {
        public long destinationRangeStart { get; set; }
        public long sourceRangeStart { get; set; }
        public long rangeLength { get; set; }
        public long destinationRangeEnd => destinationRangeStart + rangeLength - 1;
        public long sourceRangeEnd => sourceRangeStart + rangeLength - 1;
        public long increaseBy => destinationRangeStart - sourceRangeStart;

        public Range(long destinationRangeStart, long sourceRangeStart, long rangeLength) {
            this.destinationRangeStart = destinationRangeStart;
            this.sourceRangeStart = sourceRangeStart;
            this.rangeLength = rangeLength;
        }
    }
}
