using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller { 
    public partial class CRUDManager {
        public Tuple <string,bool> createUser(string username, string email, string password, string passwordc) 
        {
            using (var db = new BloggingContext())
            {
                var doesExist = db.ChennitUsers.Where(cu => cu.Email == email).FirstOrDefault();
                if (doesExist != null) return Tuple.Create("User already exists", false);

                if (password != passwordc) return Tuple.Create("Passwords do not match", false);

                db.ChennitUsers.Add(
                    new ChennitUser
                    {
                        Username = username,
                        Email = email,
                        Password = password
                    });
                db.SaveChanges();
            }
            return Tuple.Create("Successfully Registered", true);
        }
        public void deleteUser(string email)
        {
            using (var db = new BloggingContext())
            {
                ChennitUser cu = db.ChennitUsers.Where(cu => cu.Email == email).FirstOrDefault();
                db.ChennitUsers.Remove(cu);
            }
        }

        public Tuple <string,bool> loginUser(string email, string password)
        {
            using (var db = new BloggingContext())
            {
                var doesExist = db.ChennitUsers.Where(cu => cu.Email == email).FirstOrDefault();
                if (doesExist == null) return Tuple.Create("Email not registered", false);

                if (password != doesExist.Password) return Tuple.Create("Passwords do not match", false);

                SetCurrentUser(doesExist.ChennitUserId, doesExist.Email, doesExist.Username);
                return Tuple.Create(doesExist.Username + " logged in", true);
            }
        }

        public bool logoutUser()
        {
            CurrentUser.Username = "";
            CurrentUser.Email = "";
            CurrentUser.Id = -1;

            return true;
        }

        public void SetCurrentUser(int id, string email, string username)
        {
            CurrentUser.Email = email;
            CurrentUser.Id = id;
            CurrentUser.Username = username;
        }

        public string GetCurrentUser()
        {
            return $"{CurrentUser.Username} {CurrentUser.Email} {CurrentUser.Id}";
        }
    }
}
