using System.Collections.Concurrent;

namespace TracerLib.Tracer.Impl
{
    public class BenchmarkResult
    {
        private ConcurrentDictionary<int, BenchmarkThread> BenchmarksThread { get; }

        public BenchmarkResult(ConcurrentDictionary<int, BenchmarkThread> benchmarksThread)
        {
            BenchmarksThread = benchmarksThread;
        }

        public ConcurrentDictionary<int, BenchmarkThread> GetBenchmarksThread()
        {
            return BenchmarksThread;
        }

        public BenchmarkThread GetBenchmarkThreadById(int id)
        {
            return  BenchmarksThread.GetOrAdd(id, new BenchmarkThread(id));
        }
    }
}