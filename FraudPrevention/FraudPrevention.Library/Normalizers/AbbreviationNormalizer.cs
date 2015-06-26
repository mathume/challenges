using System.Collections.Generic;

namespace FraudPrevention.Normalizers
{
    public class AbbreviationNormalizer : INormalizer
    {
        private Dictionary<string, string> substitutions;

        public AbbreviationNormalizer()
        {
            this.substitutions = new Dictionary<string, string>();
            this.substitutions.Add("St.", "Street");
            this.substitutions.Add("Rd.", "Road");
            this.substitutions.Add("IL", "Illinois");
            this.substitutions.Add("CA", "California");
            this.substitutions.Add("NY", "New York");
        }

        public string Normalize(string p)
        {
            var normalized = p;
            foreach (var sub in this.substitutions)
            {
                normalized = normalized.Replace(sub.Key, sub.Value);
            }

            // TODO: needs more code for removing white space characters
            return normalized;
        }
    }
}