using System;

namespace FraudPrevention.IO
{
    public class ReaderWriterConsole : IReaderWriter
    {
        public ReaderWriterConsole() { }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}