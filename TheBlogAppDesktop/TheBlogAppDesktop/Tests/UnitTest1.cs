using Controller;
using Model;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        CRUDManager cm = new CRUDManager();

        [Test]
        public void createUserTest()
        {
            using (var db = new BloggingContext())
            {
                int originalCount = db.ChennitUsers.Count();
                cm.createUser("jasdsmie", "sdsjamie@gmail.com", "123", "123");
                Assert.AreEqual(originalCount+1, db.ChennitUsers.Count());
            }
        }

    }
}