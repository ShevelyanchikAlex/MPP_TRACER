using System.Collections.Concurrent;

namespace TracerLib.Tracer.Impl
{
    public class BenchmarkResult
    {
        private ConcurrentDictionary<int, BenchmarkThread> BenchmarkThreads { get; }

        public BenchmarkResult(ConcurrentDictionary<int, BenchmarkThread> benchmarkThreads)
        {
            BenchmarkThreads = benchmarkThreads;
        }
        
        public ConcurrentDictionary<int, BenchmarkThread> GetBenchmarkThreads()
        {
            return BenchmarkThreads;
        }

        public BenchmarkThread GetBenchmarkThreadById(int id)
        {
            return  BenchmarkThreads.GetOrAdd(id, new BenchmarkThread(id));
        }
    }
}