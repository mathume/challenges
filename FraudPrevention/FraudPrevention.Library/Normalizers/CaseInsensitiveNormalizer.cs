namespace FraudPrevention.Normalizers
{
    public class CaseInsensitiveNormalizer : INormalizer
    {
        public string Normalize(string p)
        {
            return p.ToLowerInvariant();
        }
    }
}