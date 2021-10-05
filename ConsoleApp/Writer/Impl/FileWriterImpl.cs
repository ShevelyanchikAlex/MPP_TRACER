using System;
using System.IO;
using ConsoleApp.Writer.Interfaces;

namespace ConsoleApp.Writer.Impl
{
    public class FileWriterImpl : IWriter
    {

        private string FilePath { get; }

        public FileWriterImpl(string filePath)
        {
            FilePath = filePath;
        }

        public void Write(string data)
        {
            try
            {
                var streamWriter = new StreamWriter(FilePath);
                streamWriter.WriteLine(data);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}