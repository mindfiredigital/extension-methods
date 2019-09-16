using Xunit;

namespace Extensions.UnitTest
{
    public class NumberExtensionTest
    {
        [Theory]
        [InlineData(23, "0.00", "23.00")]
        [InlineData(23.1234, "0.00", "23.12")]
        [InlineData(23.1234, "0.000000", "23.123400")]
        [InlineData(null, "0.000000", "")]
        public void ToString_nullable_ShouldPass(double? data, string format, string actual)
        {
            var res = data.ToString(format);
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData(23, "0.00", "23.00")]
        [InlineData(23.1234, "0.00", "23.12")]
        [InlineData(23.1234, "0.000000", "23.123400")]
        [InlineData(-23, "0.000000", "-23.000000")]
        public void ToString_ShouldPass(double data, string format, string actual)
        {
            var res = data.ToString(format);
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData(23, "$23.00")]
        [InlineData(0, "$0.00")]
        [InlineData(98.2311, "$98.23")]
        [InlineData(98.2389, "$98.24")]
        [InlineData(1000.00, "$1,000.00")]
        public void ToLocalCurrencyString_ShouldPass(double data, string actual)
        {
            var res = data.ToLocalCurrencyString();
            Assert.Equal(res, actual);
        }
    }
}
