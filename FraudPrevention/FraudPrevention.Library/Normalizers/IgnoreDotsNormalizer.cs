namespace FraudPrevention.Normalizers
{
    public class IgnoreDotsNormalizer : INormalizer
    {
        public string Normalize(string p)
        {
            return p.Replace(".", "");
        }
    }
}