using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;


namespace TutorTesting
{
    [TestFixture]
    public class ValidationTesting
    {
        Validation val = new Validation();
        [Test]
        [TestCase("abdge@fm.com",true)]
        [TestCase("xyz@.com",false)]
        [TestCase("asdfghjkl@gmail.in", true)]
        [TestCase("qwertyu@dfghj.", false)]
        [TestCase("wxyzgmail.com", false)]
        [TestCase("nothing@gmail.good", true)]
        [TestCase("testemail@test.validation", false)]
        [TestCase("test1234@yahoo.in", true)]
        [TestCase("working@gmail.com", true)]
        [TestCase("dummyemail$email.in", false)]
        [TestCase("validation%yahoo.c", false)]
        [TestCase("goodjob@contact.in", true)]

        public void TestEmail(string email , bool expVal)
        {
            bool actVal = val.Email(email);
            Assert.AreEqual(expVal, actVal);
        }

        [Test]
        [TestCase("9876543210",true)]
        [TestCase("8764832476", true)]
        [TestCase("238762", false)]
        [TestCase("+1 (863) 376.3863", false)]
        [TestCase("(634)(545)(5454)", false)]
        [TestCase("4589749687546498", false)]
        [TestCase("+91 6765374864", false)]
        [TestCase("6654321098",true)]
        [TestCase("7098765432",true)]
        [TestCase("4567890123",false)]
        public void TestPhone(string phone , bool expVal)
        {
            bool actVal = val.Phone(phone);
            Assert.AreEqual(expVal, actVal);
        }
    }
}
