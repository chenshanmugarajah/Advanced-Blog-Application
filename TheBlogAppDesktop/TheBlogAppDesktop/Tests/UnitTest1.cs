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

        [Test]
        public void loginUserTest()
        {
            using (var db = new BloggingContext())
            {
                string expectedEmail = "jamie@gmail.com";
                cm.loginUser(expectedEmail, "123");
                ChennitUser cu = cm.getCurrentUser();
                Assert.AreEqual(expectedEmail, cu.Email);
                cm.logoutUser();
            }
        }

        [Test]
        public void logutUserTest()
        {
            using (var db = new BloggingContext())
            {
                string expectedEmail = "jamie@gmail.com";
                cm.loginUser(expectedEmail, "123");
                int count1 = db.CurrentUsers.Count();
                cm.logoutUser();
                int count2 = db.CurrentUsers.Count();
                Assert.AreEqual(count1 - 1, count2);
                Assert.AreEqual(count2, 0);
            }
        }


    }
}