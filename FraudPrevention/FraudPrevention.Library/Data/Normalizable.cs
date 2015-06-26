using FraudPrevention.Normalizers;

namespace FraudPrevention.Data
{
    public class Normalizable
    {
        private INormalizer[] normalizers;

        public string Value { get; set; }

        public Normalizable(string value, params INormalizer[] normalizers)
        {
            this.normalizers = normalizers;
            this.Value = value;
        }

        public void Normalize()
        {
            foreach (var normalizer in this.normalizers)
            {
                this.Value = normalizer.Normalize(this.Value);
            }
        }
    }
}