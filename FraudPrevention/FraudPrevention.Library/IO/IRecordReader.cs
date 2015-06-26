using FraudPrevention.Data;

namespace FraudPrevention.IO
{
    public interface IRecordReader
    {
        /// <summary>
        /// Reads the next record
        /// </summary>
        /// <returns>The next record. null if there are no more records</returns>
        Record NextRecord();

        int NumberOfRecords { get; }
    }
}