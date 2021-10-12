using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TracerLib.Tracer.Impl
{
    [XmlType("thread")]
    public class BenchmarkThread
    {
        [JsonPropertyName("id")]
        [XmlAttribute("id")]
        public int ThreadId { get; set; }

        [JsonPropertyName("time")]
        [XmlAttribute("time")]
        public long ThreadTime { get; set; }

        [JsonPropertyName("methods")]
        [XmlElement("methods")]
        public List<MethodInfo> MethodsInfo { get; set; }

        public BenchmarkThread(int threadId)
        {
            MethodsInfo = new List<MethodInfo>();
            ThreadId = threadId;
        }

        public BenchmarkThread()
        {
        }

        public void AddMethod(string methodName, string className, string stackTraceMethodPath)
        {
            MethodsInfo.Add(new MethodInfo(methodName, className, stackTraceMethodPath));
        }

        public void DeleteMethod(string stackTraceMethodPath)
        {
            var index = MethodsInfo.FindLastIndex(item => item.GetMethodPath() == stackTraceMethodPath);

            if (index != MethodsInfo.Count - 1)
            {
                ManageInnerMethods(index);
            }

            MethodsInfo[index].CalculateElapsedTime();
            ThreadTime += MethodsInfo[index].GetElapsedTime();
        }

        private void ManageInnerMethods(int index)
        {
            var lengthOfInnerMethods = MethodsInfo.Count - 1 - index;
            var innerMethods = MethodsInfo.GetRange(index + 1, lengthOfInnerMethods);

            for (var i = 0; i < lengthOfInnerMethods; i++)
            {
                MethodsInfo.RemoveAt(MethodsInfo.Count - 1);
            }

            MethodsInfo[index].CalculateElapsedTime();
            MethodsInfo[index].SetMethods(innerMethods);
        }
    }
}