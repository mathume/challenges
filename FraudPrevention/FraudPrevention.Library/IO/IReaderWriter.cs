namespace FraudPrevention.IO
{
    public interface IReaderWriter
    {
        string ReadLine();

        void WriteLine(string line);
    }
}