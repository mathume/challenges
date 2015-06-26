using FraudPrevention.Normalizers;
using NUnit.Framework;

namespace FraudPrevention.Tests
{
    [TestFixture]
    public class Normalizers
    {
        [Test]
        public void AbbreviationNormalizer()
        {
            Assert.That(new AbbreviationNormalizer().Normalize("St. IL Rd."), Is.EqualTo("Street Illinois Road"));
        }

        [Test]
        public void CaseInsensitiveNormalizer()
        {
            Assert.That(new CaseInsensitiveNormalizer().Normalize("Ab"), Is.EqualTo("ab"));
        }

        [Test]
        public void IgnoreDotsNormalizer()
        {
            Assert.That(new IgnoreDotsNormalizer().Normalize("sebastian.mitterle@ema.il"), Is.EqualTo("sebastianmitterle@email"));
        }

        [Test]
        public void IgnorePlusNormalizer()
        {
            Assert.That(new IgnorePlusNormalizer().Normalize("sebastian+10@ema.il"), Is.EqualTo("sebastian@ema.il"));
        }
    }
}