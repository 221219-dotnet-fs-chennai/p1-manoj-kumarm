using LogicLayer;

namespace Test
{
    [TestFixture]
    public class TestingMapper
    {
        [Test]
        public void Test1() 
        {
            DataFluentApi.Entities.TrainerDetail t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.TrainerDetail)));    
        }

        [Test]
        public void Test2()
        {
            Models.TrainerDetail t = new Models.TrainerDetail();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataFluentApi.Entities.TrainerDetail)));
        }

        [Test]
        public void Test3()
        {
            DataFluentApi.Entities.TrainerLocation t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.TrainerLocation)));

        }
        [Test]
        public void Test4()
        {
            Models.TrainerLocation t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataFluentApi.Entities.TrainerLocation)));
        }

        [Test]
        public void Test5()
        {
            DataFluentApi.Entities.TrainerSkill t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.TrainerSkills)));
        }
        [Test]
        public void Test6()
        {
            Models.TrainerSkills t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(),Is.EqualTo(typeof(DataFluentApi.Entities.TrainerSkill)));
        }
        [Test]
        public void Test7()
        {
            DataFluentApi.Entities.TrainerEducation t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.TrainerEducation)));
        }

        [Test]
        public void Test8()
        {
            Models.TrainerEducation t = new();  
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataFluentApi.Entities.TrainerEducation)));
        }

        [Test]
        public void Test9()
        {
            DataFluentApi.Entities.TrainerCompany t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(Models.TrainerCompany)));
        }

        [Test]
        public void Test10()
        {
            Models.TrainerCompany t = new();
            var actual = Mapper.Map(t);
            Assert.That(actual.GetType(), Is.EqualTo(typeof(DataFluentApi.Entities.TrainerCompany)));
        }
    }
}
