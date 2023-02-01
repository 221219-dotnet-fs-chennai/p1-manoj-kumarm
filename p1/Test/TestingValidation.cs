using LogicLayer;
namespace Test
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
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
        [Test]
        public void Test1(string str, bool expected)
        {
            bool actual = Validation.IsValidEmail(str);
            Assert.AreEqual(expected, actual);
        }
    }
}