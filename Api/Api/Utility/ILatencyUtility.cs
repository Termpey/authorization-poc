namespace Utility {
    public interface ILatencyUtility<T> {

        public Task<T?> LatencyWithData(T? data);

        public Task<List<T>> LatencyWithListData(List<T> data);

        public Task Latency();
    }
}