using FraudPrevention.IO;
using NSubstitute;
using NUnit.Framework;

namespace FraudPrevention.Tests
{
    [TestFixture]
    public class Workflow
    {
        [Test]
        public void GetFraudulentRule1()
        {
            var iReaderWriterMock = writerMockWithSampleDataRule1();
            new Checker(iReaderWriterMock).Run();
            iReaderWriterMock.Received().WriteLine("1");
        }

        [Test]
        public void GetFraudulentRule2()
        {
            var iReaderWriterMock = writerMockWithSampleDataRule2();
            new Checker(iReaderWriterMock).Run();
            iReaderWriterMock.Received().WriteLine("1");
        }

        [Test]
        public void GetFraudulentAllRules()
        {
            var iReaderWriterMock = writerMockWithSampleDataAllRules();
            new Checker(iReaderWriterMock).Run();
            iReaderWriterMock.Received().WriteLine("1,2");
        }

        [Test]
        public void GetFraudulentOverlappingRules()
        {
            var iReaderWriterMock = writerMockWithSampleDataOverlappingRules();
            new Checker(iReaderWriterMock).Run();
            iReaderWriterMock.Received().WriteLine("1");
        }

        [Test]
        public void GetFraudulentFullRuleCoverage()
        {
            var iReaderWriterMock = writerMockWithFullRuleCoverage();
            new Checker(iReaderWriterMock).Run();
            iReaderWriterMock.Received().WriteLine("1,2");
        }

        private IReaderWriter writerMockWithSampleDataRule1()
        {
            var sub = Substitute.For<IReaderWriter>();
            sub.ReadLine().Returns(
                "3",
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,125 Sesame St.,New York,NY,10012,10987654321",
                "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                null);
            return sub;
        }

        private IReaderWriter writerMockWithSampleDataRule2()
        {
            var sub = Substitute.For<IReaderWriter>();
            sub.ReadLine().Returns(
                "3",
                "1,1,elma@futt.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987654321",
                "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                null);
            return sub;
        }

        private IReaderWriter writerMockWithSampleDataAllRules()
        {
            var sub = Substitute.For<IReaderWriter>();
            sub.ReadLine().Returns(
                "3",
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,125 Sesame St.,New York,NY,10012,10987654321",
                "1,2,elma@futt.com,123 Sesame St.,New York,NY,10011,12345687010",
                "2,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987658321",
                null);
            return sub;
        }

        private IReaderWriter writerMockWithSampleDataOverlappingRules()
        {
            var sub = Substitute.For<IReaderWriter>();
            sub.ReadLine().Returns(
                "3",
                "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10012,10987654321",
                "1,1,elma@futt.com,123 Sesame St.,New York,NY,10011,12345687010",
                "2,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987658321",
                null);
            return sub;
        }

        private IReaderWriter writerMockWithFullRuleCoverage()
        {
            var sub = Substitute.For<IReaderWriter>();
            sub.ReadLine().Returns(
                "3",
                "1,1,bug.s+10@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                "2,1,bugS@bunny.com,123 Sesame St.,New York,NY,10011,10987654321",
                "1,2,elma@futt.com,123 SesamE Street,New York,NY,10011,12345687010",
                "2,2,bugs@bunny.com,123 Sesame St.,New York,New York,100-11,10987658321",
                null);
            return sub;
        
        }

    }
}