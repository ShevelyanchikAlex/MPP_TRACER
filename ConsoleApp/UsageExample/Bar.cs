using System.Threading;
using TracerLib.Tracer.Interfaces;


namespace ConsoleApp.UsageExample
{
    public class Bar
    {
        private ITracer _tracer;

        public Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(150);
            _tracer.StopTrace();
        }
    }
}