using System.Threading;
using NUnit.Framework;
using Tests.UsageExample;
using TracerLib.Tracer.Impl;
using TracerLib.Tracer.Interfaces;

namespace Tests
{
    public class TracerTests
    {
        private static ITracer _tracer = new TracerImpl();
        private Foo _foo = new Foo(_tracer);


        [Test]
        public void SingleThreadTest()
        {
            _foo.MyMethod();
            Assert.AreEqual(1, _tracer.GetTraceResult().GetBenchmarkThreads().Count);
        }

        [Test]
        public void ThreadsCountTest()
        {
            Thread thread1 = new Thread(_foo.MyMethod);
            Thread thread2 = new Thread(_foo.MyMethod);
            
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            
            Assert.AreEqual(3, _tracer.GetTraceResult().GetBenchmarkThreads().Count);
        }
    }
}