using Controller;
using Model;
using NUnit.Framework;
using System;
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
                cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                Assert.AreEqual(originalCount, db.ChennitUsers.Count());
                cm.deleteUser("jamie@gmail.com");
            }
        }

        [Test]
        public void errorExistingUserTest()
        {
            using (var db = new BloggingContext())
            {
                int originalCount = db.ChennitUsers.Count();
                cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                Tuple <string, bool> response = cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                Assert.AreEqual(response.Item2, false);
                cm.deleteUser("jamie@gmail.com");
            }
        }

        [Test]
        public void errorExistingMsg()
        {
            using (var db = new BloggingContext())
            {
                int originalCount = db.ChennitUsers.Count();
                cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                Tuple<string, bool> response = cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                Assert.AreEqual(response.Item1, "User already exists");
                cm.deleteUser("jamie@gmail.com");
            }
        }

        [Test]
        public void createPostTest()
        {
            using (var db = new BloggingContext())
            {
                cm.createUser("jamie", "jamie@gmail.com", "123", "123");
                cm.loginUser("jamie@gmail.com", "123");

                int originalCount = db.Posts.Count();
                cm.createPost(1, "Title", "ContentTest!");
                Assert.AreEqual(originalCount + 1, db.Posts.Count());

                cm.deletePost("ContentTest!");
                cm.deleteUser("jamie@gmail.com");
            }
        }

        //[Test]
        //public void createUserTest()
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        int originalCount = db.ChennitUsers.Count();
        //        cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Assert.AreEqual(originalCount, db.ChennitUsers.Count());
        //        cm.deleteUser("jamie@gmail.com");
        //    }
        //}

        //[Test]
        //public void errorExistingUserTest()
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        int originalCount = db.ChennitUsers.Count();
        //        cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Tuple<string, bool> response = cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Assert.AreEqual(response.Item2, false);
        //        cm.deleteUser("jamie@gmail.com");
        //    }
        //}
        //[Test]
        //public void createUserTest()
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        int originalCount = db.ChennitUsers.Count();
        //        cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Assert.AreEqual(originalCount, db.ChennitUsers.Count());
        //        cm.deleteUser("jamie@gmail.com");
        //    }
        //}

        //[Test]
        //public void errorExistingUserTest()
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        int originalCount = db.ChennitUsers.Count();
        //        cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Tuple<string, bool> response = cm.createUser("jamie", "jamie@gmail.com", "123", "123");
        //        Assert.AreEqual(response.Item2, false);
        //        cm.deleteUser("jamie@gmail.com");
        //    }
        //}

    }
}