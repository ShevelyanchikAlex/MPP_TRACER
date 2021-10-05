using System.Threading;
using TracerLib.Tracer.Interfaces;


namespace Tests.UsageExample
{
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            Thread.Sleep(10);
            _tracer.StopTrace();
        }
    }
}