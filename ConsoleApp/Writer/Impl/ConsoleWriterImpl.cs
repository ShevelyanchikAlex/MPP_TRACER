using System;
using ConsoleApp.Writer.Interfaces;

namespace ConsoleApp.Writer.Impl
{
    public class ConsoleWriterImpl : IWriter
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}