using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FraudPrevention.Data;
using FraudPrevention.Normalizers;

namespace FraudPrevention.Tests
{
    [TestFixture]
    public class Normalizables
    {
        [Test]
        public void Concatenation()
        {
            var normalized = new Normalizable("S.a+10@ma.il", new CaseInsensitiveNormalizer(), new IgnoreDotsNormalizer(), new IgnorePlusNormalizer());
            normalized.Normalize();
            Assert.That(normalized.Value, Is.EqualTo("sa@mail"));
        }
    }
}
