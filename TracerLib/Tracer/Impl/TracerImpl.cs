using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using TracerLib.Tracer.Interfaces;

namespace TracerLib.Tracer.Impl
{
    public class TracerImpl : ITracer
    {
        private readonly BenchmarkResult _benchmarkResult;

        public TracerImpl()
        {
            _benchmarkResult = new BenchmarkResult(new ConcurrentDictionary<int, BenchmarkThread>());
        }

        public BenchmarkResult GetTraceResult()
        {
            return _benchmarkResult;
        }

        public void StartTrace()
        {
            var benchmarkThread = _benchmarkResult.GetBenchmarkThreadById(Thread.CurrentThread.ManagedThreadId);

            var stackTrace = new StackTrace();
            var path = stackTrace.ToString().Split(new[] {"\r\n"}, StringSplitOptions.None);
            path[0] = "";

            benchmarkThread.AddMethod(stackTrace.GetFrames()[1].GetMethod()?.Name,
                stackTrace.GetFrames()[1].GetMethod()?.ReflectedType.Name, string.Join("", path));
        }

        public void StopTrace()
        {
            var threadTrace = _benchmarkResult.GetBenchmarkThreadById(Thread.CurrentThread.ManagedThreadId);

            var stackTrace = new StackTrace();
            var path = stackTrace.ToString().Split(new string[] {"\r\n"}, StringSplitOptions.None);
            path[0] = "";
            
            threadTrace.DeleteMethod(string.Join("", path));
        }
    }
}