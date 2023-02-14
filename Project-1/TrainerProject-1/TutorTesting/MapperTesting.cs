using BusinessLogic;
using Models;
using det = EntityLayer.Entities; 
namespace TutorTesting
{
    public class MapperTesting
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        Mapper map = new Mapper();

        // Model to entity mapper testing
        [Test]
        public void TestMapSignup()
        {
            Trainer_Signup signup= new Trainer_Signup();
            var entity = map.MapSignup(signup);
            Assert.AreEqual(entity.GetType(),typeof(det.Signup));
        }
        [Test]
        public void TestMapLogin()
        {
            Trainer_Login login = new Trainer_Login();
            var entity = map.MapLogin(login);
            Assert.AreEqual(entity.GetType(), typeof(det.Login));
        }
        [Test]
        public void TestMapEducation()
        {
            Trainer_Education education = new Trainer_Education();
            var entity = map.MapEducation(education);
            Assert.AreEqual(entity.GetType(), typeof(det.Education));
        }
        [Test]
        public void TestMapCompany()
        {
            Trainer_Companies companies = new Trainer_Companies();
            var entity = map.MapCompany(companies);
            Assert.AreEqual(entity.GetType(), typeof(det.Company));
        }
        [Test]
        public void TestMapSkill()
        {
            Trainer_Skills skills = new Trainer_Skills();
            var entity = map.MapSkill(skills);
            Assert.AreEqual(entity.GetType(), typeof(det.Skill));
        }

        // Entity to model mapper testing

        [Test]
        public void TestMapTrainerSignup()
        {
            det.Signup signup = new det.Signup();
            var model = map.MapTrainerSignup(signup);
            Assert.AreEqual(model.GetType(),typeof(Trainer_Signup));
        }
        [Test]
        public void TestMapTrainerLogin()
        {
            det.Login login = new det.Login();
            var model = map.MapTrainerLogin(login);
            Assert.AreEqual(model.GetType(), typeof(Trainer_Login));
        }
        [Test]
        public void TestMapTrainerEducation()
        {
            det.Education education = new det.Education();
            var model = map.MapTrainerEducation(education);
            Assert.AreEqual(model.GetType(), typeof(Trainer_Education));
        }
        [Test]
        public void TestMapTrainerCompanies()
        {
            det.Company company = new det.Company();
            var model = map.MapTrainerCompanies(company);
            Assert.AreEqual(model.GetType(), typeof(Trainer_Companies));
        }
        [Test]
        public void TestMapTrainerSkills()
        {
            det.Skill skill = new det.Skill();
            var model = map.MapTrainerSkills(skill);
            Assert.AreEqual(model.GetType(), typeof(Trainer_Skills));
        }
    }
}