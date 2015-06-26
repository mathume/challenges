using FraudPrevention.Data;
using FraudPrevention.Exceptions;
using FraudPrevention.Normalizers;
using NSubstitute;
using NUnit.Framework;

namespace FraudPrevention.Tests.Unit
{
    [TestFixture]
    internal class RecordNormalizers
    {
        private INormalizer SomeNormalizer;
        private INormalizer ExceptionNormalizer;
        private const string SomeValue = "SomeValue";
        private const string NormalizedValue = "NormalizedValue";

        public RecordNormalizers()
        {
            this.SomeNormalizer = Substitute.For<INormalizer>();
            this.SomeNormalizer.Normalize(SomeValue).Returns(NormalizedValue);
            this.ExceptionNormalizer = Substitute.For<INormalizer>();
            this.ExceptionNormalizer.When(x => x.Normalize(SomeValue)).Do(x => { throw new NormalizeException(); });
        }

        [Test]
        public void NormalizersNormalize()
        {
            var n = new Record
            {
                OrderId = 1,
                DealId = 1,
                CreditCardNumber = 1,
                StreetAddress = new Normalizable(SomeValue, this.SomeNormalizer),
                State = new Normalizable(SomeValue, this.SomeNormalizer),
                City = new Normalizable(SomeValue, this.SomeNormalizer),
                ZipCode = new Normalizable(SomeValue, this.SomeNormalizer),
                EmailAddress = new Normalizable(SomeValue, this.SomeNormalizer)
            };

            n.Normalize();
            Assert.That(n.State.Value, Is.EqualTo(NormalizedValue));
        }
    }
}