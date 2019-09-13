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
        public void ToString_ShouldPass(double? data, string format, string actual)
        {
            var res = data.ToString(format);
            Assert.Equal(res, actual);
        }
    }
}
