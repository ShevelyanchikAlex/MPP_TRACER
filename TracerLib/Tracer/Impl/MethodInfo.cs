using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TracerLib.Tracer.Impl
{
    public class MethodInfo
    {
        [JsonPropertyName("time")]
        [XmlAttribute("time")]
        public double ElapsedTime { get; set; }

        [JsonPropertyName("name")]
        [XmlAttribute("name")]
        public string MethodName { get; set; }

        [JsonPropertyName("class")]
        [XmlAttribute("class")]
        public string ClassName { get; set; }

        [JsonPropertyName("methods")]
        [XmlElement("methods")]
        public List<MethodInfo> Methods { get; set; }

        [JsonIgnore] private readonly Stopwatch _stopwatch = new Stopwatch();

        [JsonIgnore] private readonly string _methodPath;

        public MethodInfo()
        {
        }

        public MethodInfo(string methodName, string className, string methodPath)
        {
            MethodName = methodName;
            ClassName = className;
            _methodPath = methodPath;
            _stopwatch.Start();
        }

        public void SetMethods(List<MethodInfo> methodsList)
        {
            Methods = methodsList;
        }

        public void CalculateElapsedTime()
        {
            _stopwatch.Stop();
            ElapsedTime = _stopwatch.ElapsedMilliseconds;
        }

        public long GetElapsedTime()
        {
            return (long) ElapsedTime;
        }

        public string GetMethodPath()
        {
            return _methodPath;
        }
    }
}