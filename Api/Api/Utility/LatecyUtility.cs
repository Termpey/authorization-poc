using System.Security.Cryptography;

namespace Utility {
    public class LatencyUtility<T> {

        private int _latencyMax = 200;

        public async Task<T?> LatencyWithData(T? data){

            await Task.Delay(RandomNumberGenerator.GetInt32(_latencyMax));

            return data;
        }

        public async Task<List<T>> LatencyWithListData(List<T> data){
            await Task.Delay(RandomNumberGenerator.GetInt32(_latencyMax));

            return data;
        }

        public async Task Latency(){
            await Task.Delay(RandomNumberGenerator.GetInt32(_latencyMax));
        }
    }
}