using System.IO;
using System.Threading;
using ConsoleApp.UsageExample;
using ConsoleApp.Writer.Impl;
using ConsoleApp.Writer.Interfaces;
using TracerLib.Serialization.Impl;
using TracerLib.Tracer.Impl;
using TracerLib.Tracer.Interfaces;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ITracer tracer = new TracerImpl();
            IWriter writer = new DefaultWriterImpl();

            Foo foo = new Foo(tracer);
            Thread thread1 = new Thread(foo.MyMethod);
            Thread thread2 = new Thread(foo.MyMethod);

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            WriteJsonResult(tracer, writer);
            WriteXmlResult(tracer, writer);
        }


        private static string GetFolderDirectory()
        {
            return string.Concat(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent, "/Assets/Files");
        }

        private static string GetFullFilePath(string file)
        {
            return Path.GetFullPath(Path.Combine(GetFolderDirectory(), file));
        }

        private static void WriteJsonResult(ITracer tracer, IWriter writer)
        {
            var resultJson = new JsonSerializeImpl().Serialize(tracer.GetTraceResult());
            writer = new FileWriterImpl(GetFullFilePath("result.json"));
            writer.Write(resultJson);
            writer = new ConsoleWriterImpl();
            writer.Write(resultJson);
        }

        private static void WriteXmlResult(ITracer tracer, IWriter writer)
        {
            var resultXml = new XmlSerializeImpl().Serialize(tracer.GetTraceResult());
            writer = new FileWriterImpl(GetFullFilePath("result.xml"));
            writer.Write(resultXml);
            writer = new ConsoleWriterImpl();
            writer.Write(resultXml);
        }
    }
}