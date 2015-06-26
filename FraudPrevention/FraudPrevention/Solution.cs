using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FraudPrevention.Data;
using FraudPrevention.IO;

namespace FraudPrevention
{
    public class Solution
    {
        private static void Main(string[] args)
        {
            new Checker(new ReaderWriterConsole()).Run();
        }
    }
}