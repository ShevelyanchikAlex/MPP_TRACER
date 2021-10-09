using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TracerLib.Serialization.Interfaces;
using TracerLib.Tracer.Impl;

namespace TracerLib.Serialization.Impl
{
    public class XmlSerializeImpl : ISerialize
    {
        public string Serialize(BenchmarkResult benchmarkResult)
        {
            var benchmarksThread = benchmarkResult.GetBenchmarkThreads().Values.ToArray();
            var xmlSerializer = new XmlSerializer(benchmarksThread.GetType());
            var sw = new StringWriter();

            using (var writer = new XmlTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                xmlSerializer.Serialize(writer, benchmarksThread);
            }

            return sw.ToString().Replace("ArrayOfThread", "root");
        }
    }
}