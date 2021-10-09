using System.Collections.Generic;
using Newtonsoft.Json;
using TracerLib.Serialization.Interfaces;
using TracerLib.Tracer.Impl;


namespace TracerLib.Serialization.Impl
{
    public class JsonSerializeImpl : ISerialize
    {
        public string Serialize(BenchmarkResult benchmarkResult)
        {
            return JsonConvert.SerializeObject(new Dictionary<string, ICollection<BenchmarkThread>>
                {{"threads", benchmarkResult.GetBenchmarkThreads().Values}}, Formatting.Indented);
        }
    }
}