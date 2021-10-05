using TracerLib.Tracer.Impl;

namespace TracerLib.Tracer.Interfaces
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        BenchmarkResult GetTraceResult();
    }
}