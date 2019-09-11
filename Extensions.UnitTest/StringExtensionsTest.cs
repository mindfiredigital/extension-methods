using Extensions.UnitTest.OtherClasses;
using System;
using System.Linq;
using Xunit;

namespace Extensions.UnitTest
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("09/10/2019", "dd/MM/yyyy", true)]
        [InlineData("09/13/2019", "dd/MM/yyyy", false)]
        [InlineData("11/28/2019", "MM/dd/yyyy", true)]
        public void IsDateTime_OnlyDateInddMMyyyy(string actual, string format, bool res)
        {
            bool isEqual = actual.IsDateTime(format);
            Assert.True(res == isEqual);
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

        [Fact]
        public void SplitTo_WithoutStringOptions_IntegerShouldPass()
        {
            var actual = new int[] { 23, 34, 56, -2, 33, 100 };
            var bar = "23,34,56,-2,33,100";
            var expected = bar.SplitTo<int>(',').ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SplitTo_WithoutStringOptions_DecimalShouldPass()
        {
            var actual = new decimal[] { 23.6M, 34.6M, 56, -2, 33, 100 };
            var bar = "23.6,34.6,56,-2,33,100";
            var expected = bar.SplitTo<decimal>(',').ToArray();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitTo_WithStringOptions_IntegerShouldPass()
        {
            var actual = new int[] { 23, 34, 56, -2, 33, 100 };
            var bar = "23,34,,56,,-2,33,100";
            var expected = bar.SplitTo<int>(StringSplitOptions.RemoveEmptyEntries, ',').ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void SplitTo_WithStringOptions_DecimalShouldPass()
        {
            var actual = new decimal[] { 23.6M, 34.6M, 56, -2, 33, 100 };
            var bar = "23.6,,34.6,56,-2,33,,100";
            var expected = bar.SplitTo<decimal>(StringSplitOptions.RemoveEmptyEntries, ',').ToArray();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("true", true)]
        [InlineData("t", true)]
        [InlineData("t ", true)]
        [InlineData("True ", true)]
        [InlineData("TRUE ", true)]
        [InlineData("yes", true)]
        [InlineData("false", false)]
        [InlineData("f ", false)]
        [InlineData("no", false)]
        [InlineData("False", false)]
        [InlineData("FALSE", false)]
        public void ToBoolean_ShouldPass(string actual, bool expected)
        {
            Assert.True(actual.ToBoolean() == expected);
        }
        [Theory]
        [InlineData("")]
        [InlineData("tR")]
        [InlineData("  ")]
        public void ToBoolean_Exception_ArgumentException(string actual)
        {
            Assert.Throws<ArgumentException>(() => actual.ToBoolean());
        }

        [Theory]
        [InlineData("Admin", 1)]
        [InlineData("PublicUser", 2)]
        [InlineData("Supervisor", 3)]
        [InlineData(" ", 0)]
        public void ToEnum_ShouldPass(string data, int expected)
        {
            var actual = Convert.ToInt32(data.ToEnum<TestEnums>());
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData(" ", "")]
        [InlineData("", "")]
        [InlineData("Swagat ", "Swagat")]
        public void GetEmptyStringIfNull_ShouldPass(string data, string expected)
        {
            Assert.True(data.GetEmptyStringIfNull() == expected);
        }
        [Theory]
        [InlineData(null, null)]
        [InlineData(" ", null)]
        [InlineData("", null)]
        [InlineData(" Swagat ", "Swagat")]
        public void GetNullIfEmptyString_ShouldPass(string data, string expected)
        {
            Assert.True(data.GetNullIfEmptyString() == expected);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        [InlineData("12 ", true)]
        [InlineData(" 112 ", true)]
        [InlineData("-112 ", true)]
        public void IsInteger_ShouldPass(string data, bool expected)
        {
            Assert.True(data.IsInteger() == expected);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        [InlineData("12 ", true)]
        [InlineData(" 112 ", true)]
        [InlineData("-112 ", true)]
        [InlineData(" -112.0 ", true)]
        [InlineData("-112.9 ", true)]
        [InlineData("123.09000 ", true)]
        public void IsDecimal_ShouldPass(string data, bool expected)
        {
            Assert.True(data.IsDecimal() == expected);
        }
    }
}
