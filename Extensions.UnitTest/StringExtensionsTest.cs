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
        [InlineData("-112.00", true)]
        [InlineData("-112.51 ", true)]
        [InlineData("112.51", true)]
        public void IsNumeric_ShouldPass(string data, bool expected)
        {
            Assert.True(data.IsNumeric() == expected);
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

        [Theory]
        [InlineData(null, null)]
        [InlineData(" Hello World", " ")]
        [InlineData("", null)]
        [InlineData("12 ", "1")]
        [InlineData(" 112 ", " ")]
        [InlineData("-112", "-")]
        [InlineData("Royal College", "R")]
        public void FirstCharacter_ShouldPass(string data, string expected)
        {
            Assert.Equal(data.FirstCharacter(), expected);
        }
        [Theory]
        [InlineData(null, null)]
        [InlineData(" Hello World", "d")]
        [InlineData("", null)]
        [InlineData("12 ", " ")]
        [InlineData(" 112 ", " ")]
        [InlineData("-112", "2")]
        [InlineData("Royal College", "e")]
        public void LastCharacter_ShouldPass(string data, string expected)
        {
            Assert.Equal(data.LastCharacter(), expected);
        }

        [Theory]
        [InlineData("Hello World", "rld", true)]
        [InlineData("Hello World ", "rld", false)]
        [InlineData("Hello World", "Orld", true)]
        [InlineData("Hello World", "World", true)]
        [InlineData("Hello World", "Hello World", true)]
        [InlineData("Hello World", "Swagat Hello World", false)]
        public void EndsWithIgnoreCase_ShouldPass(string data, string endsWith, bool expected)
        {
            Assert.True(data.EndsWithIgnoreCase(endsWith) == expected);
        }
        [Theory]
        [InlineData(null, "World", "val")]
        [InlineData("World", null, "suffix")]
        public void EndsWithIgnoreCase_ArgumentNullException_ShouldFail(string data, string suffix, string param)
        {
            Assert.Throws<ArgumentNullException>(param, () => data.EndsWithIgnoreCase(suffix));
        }

        [Theory]
        [InlineData("Hello World", "hell", true)]
        [InlineData("Hello World ", " hel", false)]
        [InlineData("Hello World", "HelLo", true)]
        [InlineData("Hello World", "Hello", true)]
        [InlineData("Hello World", "Hello World", true)]
        [InlineData("Hello World", "Swagat Hello World", false)]
        [InlineData(" Hello World", "Hello World", false)]
        [InlineData(" Hello World", " Hello World", true)]
        public void StartsWithIgnoreCase_ShouldPass(string data, string endsWith, bool expected)
        {
            Assert.True(data.StartsWithIgnoreCase(endsWith) == expected);
        }
        [Theory]
        [InlineData(null, "World", "val")]
        [InlineData("World", null, "prefix")]
        public void StartsWithIgnoreCase_ArgumentNullException_ShouldFail(string data, string prefix, string param)
        {
            Assert.Throws<ArgumentNullException>(param, () => data.StartsWithIgnoreCase(prefix));
        }

        [Theory]
        [InlineData("swagat", "Swagat")]
        [InlineData(" swagat", " swagat")]
        [InlineData("swagat kumar swain", "Swagat kumar swain")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void Capitalize_ShouldPass(string data, string actual)
        {
            Assert.Equal(data.Capitalize(), actual);
        }

        [Theory]
        [InlineData("swagat swain", "s,w,a,i,n", "gt ")]
        [InlineData("swagat swain ", " ", "swagatswain")]
        public void RemoveChars_ShouldPass(string data, string replaceString, string actual)
        {
            var res = data.RemoveChars(replaceString.ToCharArray());
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("swagat swain", "S,w,a,i,n", "gt ")]
        [InlineData("swagat swain ", " ", "swagatswain")]
        public void RemoveCharsIgnoreCase_ShouldPass(string data, string replaceString, string actual)
        {
            var res = data.RemoveCharsIgnoreCase(replaceString.ToCharArray());
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("swagat swain", "swain", "swagat ")]
        [InlineData("swagat swain", "ain", "swagat sw")]
        [InlineData("swagat swain", "Swagat", "swagat swain")]
        [InlineData("swagat swain is swagat swain", "swagat", " swain is  swain")]
        [InlineData("swagat swain is swagat swain", "is swagat swain", "swagat swain ")]
        [InlineData("swagat swain is swagat swain", "agat swain", "sw is sw")]
        public void RemoveString_ShouldPass(string data, string replaceString, string actual)
        {
            var res = data.RemoveString(replaceString);
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData("swagat swain", "swain", "swagat ")]
        [InlineData("swagat swain", "SWAIN", "swagat ")]
        [InlineData("swagat swain", "ain", "swagat sw")]
        [InlineData("swagat swain", "Swagat", " swain")]
        [InlineData("swagat swain is swagat swain", "swagat", " swain is  swain")]
        [InlineData("swagat swain is swagat swain", "is SWagat swain", "swagat swain ")]
        [InlineData("swagat swain is swagat swain", "agat swain", "sw is sw")]
        public void RemoveStringIgnoreCase_ShouldPass(string data, string replaceString, string actual)
        {
            var res = data.RemoveStringIgnoreCase(replaceString);
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData("Swagat", "tagawS")]
        [InlineData(" ", " ")]
        [InlineData("Mahesh Chand is a founder of C# Corner", "renroC #C fo rednuof a si dnahC hsehaM")]
        public void Reverse_ShouldPass(string input, string actual)
        {
            var res = input.Reverse();
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData("Mahesh Chand is a founder of C# Corner", "Chand", 1)]
        [InlineData("Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner", "mahesh", 0)]
        [InlineData("Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner", "Mahesh", 2)]
        [InlineData("Mahesh Chand is a founder of C# Corner Mahesh Chand is a founder of C# Corner", "Mahesh", 2)]
        [InlineData("Mahesh Chand is a founder of C# Corner Mahesh Chand is a founder of C# Corner", "a", 6)]
        [InlineData("Mahesh Chand is a founder of C# Corner Mahesh Chand is a founder of C# Corner", "Swagat", 0)]
        public void CountOccurrences_ShouldPass(string input, string matchString, int count)
        {
            var res = input.CountOccurrences(matchString);
            Assert.Equal(res, count);
        }
        [Theory]
        [InlineData("Mahesh Chand is a founder of C# Corner", "Chand", 1)]
        [InlineData("Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner", "mahesh", 2)]
        [InlineData("Mahesh Chand is a founder of C# CornerMahesh Chand is a founder of C# Corner", "Mahesh", 2)]
        [InlineData("Mahesh Chand is a founder of C# Corner Mahesh Chand is a founder of C# Corner", "Mahesh", 2)]
        [InlineData("MAhesh Chand is a founder of C# Corner MAhesh Chand is a founder of C# Corner", "a", 6)]
        [InlineData("Mahesh Chand is a founder of C# Corner Mahesh Chand is a founder of C# Corner", "Swagat", 0)]
        public void CountOccurrencesIgnoreCase_ShouldPass(string input, string matchString, int count)
        {
            var res = input.CountOccurrencesIgnoreCase(matchString);
            Assert.Equal(res, count);
        }

        [Theory]
        [InlineData("Swagat Kumar Swain", "Swa", true, "gat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "Swa", false, "gat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "swag", false, "Swagat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "swag", true, "at Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "Swain", true, "Swagat Kumar Swain")]
        public void RemovePrefix_ShouldPass(string data, string prefix, bool ignoreCase, string actual)
        {
            var res = data.RemovePrefix(prefix, ignoreCase);
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("Swagat Kumar Swain", "Swa", true, "Swagat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "Swain", true, "Swagat Kumar ")]
        [InlineData("Swagat Kumar Swain", "Swain", false, "Swagat Kumar ")]
        [InlineData("Swagat Kumar Swain", "swain", true, "Swagat Kumar ")]
        [InlineData("Swagat Kumar Swain", "swain", false, "Swagat Kumar Swain")]
        public void RemoveSuffix_ShouldPass(string data, string suffix, bool ignoreCase, string actual)
        {
            var res = data.RemoveSuffix(suffix, ignoreCase);
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("Swagat Kumar", " ,Swain", true, "Swagat Kumar ,Swain")]
        [InlineData("Swagat Kumar", " ,Swain", false, "Swagat Kumar ,Swain")]
        [InlineData("Swagat Kumar Swain", "swain", true, "Swagat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "swain", false, "Swagat Kumar Swainswain")]
        [InlineData("Swagat Kumar Swain", "Swain", true, "Swagat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "Swain", false, "Swagat Kumar Swain")]
        public void AppendSuffixIfMissing_ShouldPass(string data, string suffix, bool ignoreCase, string actual)
        {
            var res = data.AppendSuffixIfMissing(suffix, ignoreCase);
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData("Swagat Kumar", "Swagat", true, "Swagat Kumar")]
        [InlineData("Swagat Kumar", "Swagat", false, "Swagat Kumar")]
        [InlineData("Swagat Kumar Swain", "swagat", true, "Swagat Kumar Swain")]
        [InlineData("Swagat Kumar Swain", "swagat", false, "swagatSwagat Kumar Swain")]
        public void AppendPrefixIfMissing_ShouldPass(string data, string suffix, bool ignoreCase, string actual)
        {
            var res = data.AppendPrefixIfMissing(suffix, ignoreCase);
            Assert.Equal(res, actual);
        }

        [Theory]
        [InlineData("AbcDas", true)]
        [InlineData("Abc Das", true)]
        [InlineData("Abc90Das", false)]
        [InlineData("Abc$#3Das", false)]
        public void IsAlpha_ShouldPass(string data, bool actual)
        {
            var res = data.IsAlpha();
            Assert.True(res == actual);
        }
        [Theory]
        [InlineData("AbcDas", true)]
        [InlineData("1233", true)]
        [InlineData("Abc90Das", true)]
        [InlineData("Abc90DasA#$", false)]
        public void IsAlphaNumeric_ShouldPass(string data, bool actual)
        {
            var res = data.IsAlphaNumeric();
            Assert.True(res == actual);
        }
        [Theory]
        [InlineData("ssswagatss@gmail.com", true)]
        [InlineData("ssswagat.ss@gmail.com", true)]
        [InlineData("ssswagatss@gmail.co.in", true)]
        [InlineData("23@gmail.com", false)]
        [InlineData("23ssswagatss@gmail.com", false)]
        [InlineData("ssswagatss1992@gmail.com", true)]
        [InlineData("ssswagatss1992gmail.com", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        [InlineData("23+12@gmail.com", false)]
        [InlineData("23+12@gmail.co.in.com", false)]
        public void IsEmailAddress_ShouldPass(string data, bool actual)
        {
            var res = data.IsEmailAddress();
            Assert.True(res == actual);
        }
        [Theory]
        [InlineData("ssswagatss@gmail.com", false)]
        [InlineData("192.168.1.1", true)]
        [InlineData("192.168", false)]
        [InlineData("123", false)]
        [InlineData(".1.1", false)]
        [InlineData("1.1.1.1", true)]
        public void IsIPv4_ShouldPass(string data, bool actual)
        {
            var res = data.IsIPv4();
            Assert.True(res == actual);
        }

        [Theory]
        [InlineData("Swagat Kumar Swain", 0, "")]
        [InlineData("Swagat Kumar Swain", 8, "Swagat K")]
        public void Left_ShouldPass(string data, int length, string actual)
        {
            var res = data.Left(length);
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("", "val", 12)]
        [InlineData(null, "val", 12)]
        [InlineData("Swah", "length", 12)]
        public void Left_ArgumentNullException_ShouldFail(string data, string param, int length)
        {
            if (param == "val")
                Assert.Throws<ArgumentNullException>(param, () => data.Left(length));
            else
                Assert.Throws<ArgumentOutOfRangeException>(param, () => data.Left(length));
        }


        [Theory]
        [InlineData("Swagat Kumar Swain", 0, "")]
        [InlineData("Swagat Kumar Swain", 8, "ar Swain")]
        [InlineData("Swagat Kumar Swain", 2, "in")]
        public void Right_ShouldPass(string data, int length, string actual)
        {
            var res = data.Right(length);
            Assert.Equal(res, actual);
        }
        [Theory]
        [InlineData("", "val", 12)]
        [InlineData(null, "val", 12)]
        [InlineData("Swah", "length", 12)]
        public void Right_ArgumentNullException_ShouldFail(string data, string param, int length)
        {
            if (param == "val")
                Assert.Throws<ArgumentNullException>(param, () => data.Right(length));
            else
                Assert.Throws<ArgumentOutOfRangeException>(param, () => data.Right(length));
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("Swag", false)]
        [InlineData("  ", false)]
        public void IsNull_ShouldPass(string data, bool actual)
        {
            Assert.True(data.IsNull() == actual);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("Swag", false)]
        [InlineData("  ", false)]
        public void IsNullOrEmpty_ShouldPass(string data, bool actual)
        {
            Assert.True(data.IsNullOrEmpty() == actual);
        }
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("Swag", false)]
        [InlineData("  ", true)]
        public void IsNullOrWhiteSpace_ShouldPass(string data, bool actual)
        {
            Assert.True(data.IsNullOrWhiteSpace() == actual);
        }
        [Theory]
        [InlineData(null, 0, false)]
        [InlineData("", 0, true)]
        [InlineData("Swag", 5, false)]
        [InlineData("Swag", 2, true)]
        [InlineData("Swag ", 5, true)]
        public void IsMinlength_ShouldPass(string data, int length, bool actual)
        {
            Assert.True(data.IsMinLength(length) == actual);
        }
        [Theory]
        [InlineData(null, 0, false)]
        [InlineData("", 0, true)]
        [InlineData("Swag", 5, true)]
        [InlineData("Swag", 2, false)]
        [InlineData("Swag ", 5, true)]
        public void IsMaxLength_ShouldPass(string data, int length, bool actual)
        {
            Assert.True(data.IsMaxLength(length) == actual);
        }

        [Theory]
        [InlineData(null, 0, 0, false)]
        [InlineData("", 0, 0, true)]
        [InlineData("", 1, 5, false)]
        [InlineData("Swag", 2, 5, true)]
        [InlineData("Swag  ", 2, 5, false)]
        public void IsLength_ShouldPass(string data, int min, int max, bool actual)
        {
            Assert.True(data.IsLength(min, max) == actual);
        }
        [Theory]
        [InlineData("FirstName", "First Name")]
        [InlineData("Firstname", "Firstname")]
        [InlineData("", "")]
        [InlineData("First Name", "First Name")]
        public void ToHumanCase_ShouldPass(string data, string actual)
        {
            Assert.Equal(data.ToHumanCase(), actual);
        }

        [Theory]
        [InlineData("FirstName", 4, "Firs")]
        [InlineData("Firstname", 0, "")]
        [InlineData("", 5, "")]
        [InlineData("First Name", 17, "First Name")]
        public void Truncate_ShouldPass(string data, int length, string actual)
        {
            Assert.Equal(data.Truncate(length), actual);
        }

        [Theory]
        [InlineData("Swagat Swain","swagat",true)]
        [InlineData("Swagat Swain", "Swagat", false)]
        [InlineData(" ","swagat",true)]
        [InlineData("","swagat",true)]
        public void DoesNotStartWith_ShouldPass(string data, string startsWith, bool actual)
        {
            Assert.True(data.DoesNotStartWith(startsWith)== actual);
        }

        [Theory]
        [InlineData("Swagat Swain", "swain", true)]
        [InlineData("Swagat Swain", "Swain", false)]
        [InlineData(" ", "Swain", true)]
        [InlineData("", "Swain", true)]
        public void DoesNotEndWith_ShouldPass(string data, string startsWith, bool actual)
        {
            Assert.True(data.DoesNotEndWith(startsWith) == actual);
        }

        [Theory]
        [InlineData("Swagat Swain", "swagat", false)]
        [InlineData("Swagat Swain", "Swagat", false)]
        [InlineData(" ", "swagat", true)]
        [InlineData("", "swagat", true)]
        public void DoesNotStartWith_IgnoreCase_ShouldPass(string data, string startsWith, bool actual)
        {
            Assert.True(data.DoesNotStartWith(startsWith,true) == actual);
        }

        [Theory]
        [InlineData("Swagat Swain", "swain", false)]
        [InlineData("Swagat Swain", "Swain", false)]
        [InlineData(" ", "Swain", true)]
        [InlineData("", "Swain", true)]
        public void DoesNotEndWith_IgnoreCase_ShouldPass(string data, string startsWith, bool actual)
        {
            Assert.True(data.DoesNotEndWith(startsWith, true) == actual);
        }
    }
}
