using System.Text.RegularExpressions;

namespace FraudPrevention.Normalizers
{
    public class IgnorePlusNormalizer : INormalizer
    {
        private Regex re;

        public IgnorePlusNormalizer()
        {
            this.re = new Regex(@"(.+?)(\+.*?)(@.*)");
        }

        public string Normalize(string p)
        {
            var groups = this.re.Match(p).Groups;
            return string.Join("", groups[1], groups[3]);
        }
    }
}