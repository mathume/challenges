using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FraudPrevention.IO;
using FraudPrevention.Data;
using System.Globalization;

namespace FraudPrevention
{
    public class Checker
    {
        private IReaderWriter readerWriter;
        public Checker(IReaderWriter readerWriter)
        {
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            var reader = new RecordReader(this.readerWriter);
            var records = new List<Record>();
            Record record = reader.NextRecord();
            while (record != null)
            {
                record.Normalize();
                records.Add(record);
                record = reader.NextRecord();
            }

            var checker = new CheckRecords(records);
            readerWriter.WriteLine(string.Join(",", checker.CheckForFraudulentOrderIds().Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray()));
        }
    }
}
