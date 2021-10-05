using TracerLib.Tracer.Impl;

namespace TracerLib.Serialization.Interfaces
{
    public interface ISerialize
    {
        public string Serialize(BenchmarkResult benchmarkResult);
    }
}