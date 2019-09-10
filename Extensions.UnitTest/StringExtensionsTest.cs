using Extensions.UnitTest.OtherClasses;
using Xunit;

namespace Extensions.UnitTest
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("09/10/2019", "dd/MM/yyyy", true)]
        [InlineData("09/13/2019", "dd/MM/yyyy", false)]
        [InlineData("11/28/2019", "MM/dd/yyyy",true)]
        public void IsDateTime_OnlyDateInddMMyyyy(string actual, string format, bool res)
        {
            bool isEqual = actual.IsDateTime(format);
            Assert.Equal(res, isEqual);
        }

        [Theory]
        [InlineData(12, "Swagat Swain", 25, ",", "12,Swagat Swain,25")]
        [InlineData(40, "", 25, "|", "40||25")]
        [InlineData(40, null, 25, "|", "40||25")]
        public void ToCSVString_TestUser(int id, string name, int age, string separator, string result)
        {
            var user = new TestUser { TestUserId = id, Name = name, Age = age };
            Assert.Equal(result, user.ToCSVString(separator));
        }
    }
}
