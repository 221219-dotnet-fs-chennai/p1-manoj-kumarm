using LogicLayer;
namespace Test
{
    [TestFixture]
    public class TestingValidation
    {

        [SetUp]
        public void Setup(){}

        [TestCase("", false)] 
        [TestCase(" ", false)] 
        [TestCase("xyzkml.@gmail.com", false)]
        [TestCase("xyz.@gmail.com", false)]
        [TestCase("xyzmail.com", false)]
        [TestCase("xyz@mail", false)]
        [TestCase("xyz#@mail.com", false)]
        [TestCase("xyz@@gmail.com", false)]
        [TestCase("xyz-@gmail.com", false)]
        [TestCase("xyz_@gmail.com", false)]
        [TestCase("xyz!@gmail.com", false)]
        [TestCase("xyz$@gmail.com", false)]
        [TestCase("xyz.@gmail.com", false)]
        [TestCase("xyz.@.gmail.com", false)]
        [TestCase("xyz@#gmail.com", false)]
        [TestCase("xyz@.gmail.com", false)]
        [TestCase("xyz.@gmail.com", false)]
        [TestCase("xyz@gmail.com.", false)]
        [TestCase("xyz@gmail.com!", false)]
        [TestCase("xyz@gmail.com#", false)]
        [TestCase("_@email.com", false)]
        [TestCase("@email.com", false)]
        [TestCase("@gmail.com", false)]
        [TestCase("@gmail@yahoo.com", false)]
        [TestCase("abcdef123@outlook.com.", false)]
        [TestCase("abcdef.123.@gmail.com", false)]
        [TestCase("abcdef123.@gmail.com", false)]
        [TestCase("abcdef#$123@gmail.com", false)]
        [TestCase("xyz.kml05@gmail.com", true)]
        [TestCase("abcdef@yahoo.com", true)]
        [TestCase("abcdef@gmail.com", true)]
        [TestCase("abcdef@outlook.com", true)]
        [TestCase("abcdef123@outlook.com", true)]
        [TestCase("abcdef.123@gmail.com", true)]
        [Test]
        public void Test1(string str, bool expected)
        {
            bool actual = Validation.IsValidEmail(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("xyz", false)]
        [TestCase("xyzabc", false)]
        [TestCase("xyzabcklm", false)]
        [TestCase("xyzabcklm!", false)]
        [TestCase("xyzabcklm!@", false)]
        [TestCase("98745263", false)]
        [TestCase("98745a!", false)]
        [TestCase("abcd12@#", true)]
        [TestCase("xyzabcklm!@3", true)]
        [TestCase("98745aB_", true)]
        [Test]
        public void Test2(string str, bool expected)
        {
            bool actual = Validation.IsValidPassword(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("12345", false)]
        [TestCase("123456789", false)]
        [TestCase("0123456789", false)]
        [TestCase("1234567890", false)]
        [TestCase("2234567890", false)]
        [TestCase("3234567890", false)]
        [TestCase("4234567890", false)]
        [TestCase("5234567890", false)]
        [TestCase("523456789a", false)]
        [TestCase("523456789.", false)]
        [TestCase("523456789!", false)]
        [TestCase("6234567890", true)]
        [TestCase("7234567890", true)]
        [TestCase("8234567890", true)]
        [TestCase("9234567890", true)]
        [Test]
        public void Test3(string str, bool expected)
        {
            bool actual = Validation.IsValidPhone(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("https:/google.com", false)]
        [TestCase("https:google.com", false)]
        [TestCase("http:/google.com", false)]
        [TestCase("http:google.com", false)]
        [TestCase("http:.com", false)]
        [TestCase(".com", false)]
        [TestCase("www.", false)]
        [TestCase("www.!com", false)]
        [TestCase("wcom", false)]
        [TestCase("wcom.", false)]
        [TestCase("http:///dotnet.com", false)]
        [TestCase("xyz.com", true)]
        [TestCase("xyz102.com", true)]
        [TestCase("www.google.com", true)]
        [TestCase("https://xyz.com", true)]
        [TestCase("https://www.xyz.com", true)]
        [TestCase("http://abc.com", true)]
        [TestCase("http://www.abc.com", true)]
        [TestCase("www.kml", true)]
        [TestCase("www.kml/blog", true)]
        [TestCase("www.kml/#", true)]
        [TestCase("www.kml:5050", true)]
        [TestCase("t.kml", true)]
        [TestCase("ig.kml", true)]
        [TestCase("101_regix.com", true)]
        [TestCase("https://regex101.com", true)]
        [TestCase("https://regex101.com/r/mkfE4Y/1", true)]
        [TestCase("https://regex101.com/mk%fE4Y", true)]
        [TestCase("https://regex101.com/mkfE4Y/q=1&", true)]
        [TestCase("http://dotnet.c#.and.the", true)]
        [Test]
        public void Test4(string str, bool expected)
        {
            bool actual = Validation.IsValidWebsite(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("m", false)]
        [TestCase("f", false)]
        [TestCase("o", false)]
        [TestCase("mal", false)]
        [TestCase("fema", false)]
        [TestCase("othe", false)]
        [TestCase("123", false)]
        [TestCase("@1male", false)]
        [TestCase("male", true)]
        [TestCase("female", true)]
        [TestCase("others", true)]
        [Test]
        public void Test5(string str, bool expected)
        {
            bool actual = Validation.IsValidGender(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("0", false)]
        [TestCase("00", false)]
        [TestCase(".1", false)]
        [TestCase("6", false)]
        [TestCase("a", false)]
        [TestCase("@", false)]
        [TestCase("0.", false)]
        [TestCase("0.0", false)]
        [TestCase("10", false)]
        [TestCase(".", false)]
        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("3", true)]
        [TestCase("4", true)]
        [TestCase("5", true)]
        [TestCase("1.1", true)]
        [TestCase("2.2", true)]
        [TestCase("3.3", true)]
        [TestCase("4.4", true)]
        [TestCase("5.5", true)]
        [Test]
        public void Test6(string str, bool expected)
        {
            bool actual = Validation.IsValidGpa(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("1", false)]
        [TestCase("2", false)]
        [TestCase("3", false)]
        [TestCase("20", false)]
        [TestCase("100", false)]
        [TestCase("and", false)]
        [TestCase("@2000", false)]
        [TestCase("$", false)]
        [TestCase("@/", false)]
        [TestCase("1534", false)]
        [TestCase("1634", false)]
        [TestCase("1734", false)]
        [TestCase("1834", false)]
        [TestCase("2000", true)]
        [TestCase("1985", true)]
        [TestCase("1915", true)]
        [TestCase("2014", true)]
        [TestCase("2004", true)]
        [TestCase("1905", true)]
        [Test]
        public void Test7(string str, bool expected)
        {
            bool actual = Validation.IsValidYear(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("a", false)]
        [TestCase("0", false)]
        [TestCase("0.", false)]
        [TestCase("0.!", false)]
        [TestCase("@", false)]
        [TestCase("2", false)]
        [TestCase("5600011", false)]
        [TestCase("560001", true)]
        [TestCase("100021", true)]
        [TestCase("200021", true)]
        [TestCase("300021", true)]
        [TestCase("400021", true)]
        [TestCase("500021", true)]
        [TestCase("600021", true)]
        [TestCase("700021", true)]
        [TestCase("800021", true)]
        [TestCase("900021", true)]
        [Test]
        public void Test8(string str, bool expected)
        {
            bool actual = Validation.IsValidZipcode(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("@", false)]
        [TestCase("@#@", false)]
        [TestCase("a", false)]
        [TestCase("aa", false)]
        [TestCase("xyz", true)]
        [TestCase("c++", false)]
        [TestCase("c#", false)]
        [TestCase("1", false)]
        [TestCase("12", false)]
        [TestCase("12123", false)]
        [TestCase("cpp", true)]
        [TestCase("csharpe", true)]
        [TestCase("dotnet", true)]
        [Test]
        public void Test9(string str, bool expected)
        {
            bool actual = Validation.IsValidSkill(str);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("ada", false)]
        [TestCase("@3", false)]
        [TestCase("@#", false)]
        [TestCase("0", false)]
        [TestCase("10", true)]
        [TestCase("17", true)]
        [TestCase("18", true)]
        [TestCase("50", true)]
        [TestCase("50", true)]
        [TestCase("100", true)]
        [Test]
        public void Test10(string str, bool expected)
        {
            bool actual = Validation.IsValidAge(str);
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void CleanUp(){}
    }
}