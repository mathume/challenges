using FraudPrevention.Data;
using FraudPrevention.Normalizers;
using System.Text.RegularExpressions;

namespace FraudPrevention.IO
{
    public class RecordReader : IRecordReader
    {
        private IReaderWriter readerWriter;
        private int numberOfRecords;

        public RecordReader(IReaderWriter readerWriter)
        {
            this.readerWriter = readerWriter;
            this.setNumberOfRecords(readerWriter);
        }

        private void setNumberOfRecords(IReaderWriter readerWriter)
        {
            var value = readerWriter.ReadLine().Trim();
            value = Regex.Replace(value, "[^0-9]", "", RegexOptions.None);
            this.numberOfRecords = int.Parse(value);
        }

        public Record NextRecord()
        {
            var line = this.readerWriter.ReadLine();
            if (line == null)
            {
                return null;
            }

            var data = line.Split(',');
            return new Record
            {
                OrderId = long.Parse(data[0]),
                DealId = long.Parse(data[1]),
                EmailAddress = new Normalizable(data[2], new IgnoreDotsNormalizer(), new IgnorePlusNormalizer(), new CaseInsensitiveNormalizer()),
                StreetAddress = new Normalizable(data[3], new AbbreviationNormalizer(), new CaseInsensitiveNormalizer()),
                City = new Normalizable(data[4], new AbbreviationNormalizer(), new CaseInsensitiveNormalizer()),
                State = new Normalizable(data[5], new AbbreviationNormalizer(), new CaseInsensitiveNormalizer()),
                ZipCode = new Normalizable(data[6], new DashNormalizer()),
                CreditCardNumber = long.Parse(data[7])
            };
        }

        public int NumberOfRecords
        {
            get { return this.numberOfRecords; }
        }
    }
}