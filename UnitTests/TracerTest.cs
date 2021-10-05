using System.Threading;
using ConsoleApp.UsageExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLib.Tracer.Impl;
using TracerLib.Tracer.Interfaces;


namespace UnitTests
{
    [TestClass]
    class TracerTest
    {
        private ITracer _tracer;
        private Foo _foo;

        [TestInitialize]
        public void Initialize()
        {
            _tracer = new TracerImpl();
            _foo = new Foo(_tracer);
        }

        [TestMethod]
        public void SingleThreadTest()
        {
            _foo.MyMethod();
            Assert.Equals(1, _tracer.GetTraceResult().GetBenchmarksThread().Count);
        }

        [TestMethod]
        public void ThreadsCountTest()
        {
            Thread thread1 = new Thread(_foo.MyMethod);
            Thread thread2 = new Thread(_foo.MyMethod);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Assert.AreEqual(4, _tracer.GetTraceResult().GetBenchmarksThread().Count);
        }
    }
}