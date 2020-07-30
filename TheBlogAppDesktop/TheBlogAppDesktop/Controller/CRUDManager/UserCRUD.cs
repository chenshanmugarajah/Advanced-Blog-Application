//using Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Controller
//{
//    public partial class CRUDManager
//    {
//        public string createUser(string username, string email, string password, string password2)
//        {
//            if (password != password2) return "Passwords do not match!";

//            using (var db = new BloggingContext())
//            {
//                ChennitUser chennitUser = db.ChennitUsers.Where(cu => cu.Email == email).FirstOrDefault();
//                if (chennitUser != null) return "Email already registered";

//                db.ChennitUsers.Add(
//                    new ChennitUser
//                    {
//                        Username = username,
//                        Email = email,
//                        Password = password
//                    });
//                db.SaveChanges();
//            }
//            return "Successful register!";
//        }
//        public string loginUser(string email, string password)
//        {
//            using (var db = new BloggingContext())
//            {
//                ChennitUser cu = db.ChennitUsers.Where(cu => cu.Email == email).FirstOrDefault();
//                if (cu == null) return "Email not registered";
//                if (cu.Password != password) return "Password incorrect";

//                db.CurrentUsers.Add(
//                    new CurrentUser
//                    {
//                        Email = email
//                    });
//                db.SaveChanges();
//            }
//            return "Successful Login";
//        }
//        public ChennitUser getCurrentUser()
//        {
//            using (var db = new BloggingContext())
//            {
//                return db.ChennitUsers.Where(cu => cu.Email == db.CurrentUsers.FirstOrDefault().Email).FirstOrDefault();
//            }
//        }
//        public void logoutUser()
//        {
//            using (var db = new BloggingContext())
//            {
//                try
//                {
//                    CurrentUser cu = db.CurrentUsers.First();
//                    if (cu != null)
//                    {
//                        db.CurrentUsers.Remove(cu);
//                    }
//                    db.SaveChanges();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("No logged in user");
//                }
//            }
//        }
//    }
//}
