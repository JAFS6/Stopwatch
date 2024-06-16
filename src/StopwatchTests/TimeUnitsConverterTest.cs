using StopwatchApplication.Converters;

namespace StopwatchTests
{
    [TestClass]
    public class TimeUnitsConverterTest
    {
        [TestMethod]
        [DataRow(0, 0, 0, 0)]
        [DataRow(1000, 1, 0, 0)]
        [DataRow(60000, 0, 1, 0)]
        [DataRow(3600000, 0, 0, 1)]
        [DataRow(19654000, 34, 27, 5)]
        public void ConversionWorks(long milliseconds, int expectedSeconds, int expectedMinutes, int expectedHours)
        {
            // Arrange
            var target = new TimeUnitsConverter();

            // Act
            short seconds = target.GetSeconds(milliseconds);
            short minutes = target.GetMinutes(milliseconds);
            short hours = target.GetHours(milliseconds);

            // Assert
            Assert.AreEqual((short)expectedSeconds, seconds);
            Assert.AreEqual((short)expectedMinutes, minutes);
            Assert.AreEqual((short)expectedHours, hours);
        }
    }
}