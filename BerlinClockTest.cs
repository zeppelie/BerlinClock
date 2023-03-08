using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        [TestCase("00:00:00", "OOOO")]
        [TestCase("23:59:59", "YYYY")]
        [TestCase("12:32:00", "YYOO")]
        [TestCase("12:34:00", "YYYY")]
        [TestCase("12:35:00", "OOOO")]
        public void SingleMinuteRow(string time, string expectedOutput)
        {
            var minutes = time.Split(':')[1];
            var result = BerlinkClock.SingleMinuteRow(minutes);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("00:00:00", "OOOOOOOOOOO")]
        [TestCase("23:59:59", "YYRYYRYYRYY")]
        [TestCase("12:04:00", "OOOOOOOOOOO")]
        [TestCase("12:23:00", "YYRYOOOOOOO")]
        [TestCase("12:35:00", "YYRYYRYOOOO")]
        public void FiveMinuteRow(string time, string expectedOutput)
        {
            var minutes = time.Split(':')[1];
            var result = BerlinkClock.FiveMinuteRow(minutes);

            Assert.AreEqual(expectedOutput, result);
        }
        
        [Test]
        [TestCase("00:00:00","OOOO")]
        [TestCase("23:59:59","RRRO")]
        [TestCase("02:04:00","RROO")]
        [TestCase("08:23:00","RRRO")]
        [TestCase("14:35:00","RRRR")]
        public void SingleHourRow(string time, string expectedOutput)
        {
            var hours = time.Split(':')[0];
            var result = BerlinkClock.SingleHourRow(hours);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("00:00:00", "OOOO")]
        [TestCase("23:59:59", "RRRR")]
        [TestCase("02:04:00", "OOOO")]
        [TestCase("08:23:00", "ROOO")]
        [TestCase("16:35:00", "RRRO")]
        public void FiveHourRow(string time, string expectedOutput)
        {
            var hours = time.Split(':')[0];
            var result = BerlinkClock.FiveHourRow(hours);

            Assert.AreEqual(expectedOutput, result);
        }
        
        [Test]
        [TestCase("00:00:00","Y")]
        [TestCase("23:59:59","O")]
        public void SingleSecondLamp(string time, string expectedOutput)
        {
            var seconds = time.Split(':')[2];
            var result = BerlinkClock.SingleSecondLamp(seconds);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("00:00:00", "YOOOOOOOOOOOOOOOOOOOOOOO")]
        [TestCase("23:59:59", "ORRRRRRROYYRYYRYYRYYYYYY")]
        [TestCase("16:50:06", "YRRROROOOYYRYYRYYRYOOOOO")]
        [TestCase("11:37:01", "ORROOROOOYYRYYRYOOOOYYOO")]
        public void EntireTimeConverted(string time, string expectedOutput)
        {
            var clockTime = time.Split(':');
            var result = BerlinkClock.Convert(clockTime);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}