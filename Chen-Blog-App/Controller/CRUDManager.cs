using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class CRUDManager
    {
        public BlogUser CurrentUser { get; set; } // logged in user
        public BlogThread SelectedThread { get; set; } // user selected thread
        public Post SelectedPost { get; set; } // user selected post



        public string createUser(string username, string email, string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                return "Passwords entered do not match";
            }

            BlogUser user = new BlogUser { Username = username, Email = email, Passowrd = password };

            using (var db = new BloggingContext())
            {
                db.BlogUsers.Add(user);

                return $"Sucessfully registered {username}";
            }

        }

        public string loginUser(string username, string password)
        {
            using (var db = new BloggingContext())
            {
                BlogUser doesExist = db.BlogUsers.Where(u => u.Username == username).FirstOrDefault();

                if (doesExist != null)
                {
                    if (doesExist.Passowrd == password)
                    {
                        setCurrentUser(doesExist);
                        return "Sucessfully logged in";
                    }
                }

                return "Error logging in";
            }
        }

        public string logoutUser()
        {
            if (CurrentUser != null)
            {
                CurrentUser = null;
                return "Logged out";
            }

            return "No one logged in";
        }

        public void setCurrentUser (object item)
        {
            CurrentUser = (BlogUser)item;
        }




        public List<BlogThread> getAllPosts()
        {
            using (var db = new BloggingContext())
            {
                return db.BlogThreads.ToList();
            }
        }

        public List<Post> getUserPosts(BlogUser user)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Where(p => p.BlogUserId == user.BlogUserId).ToList();
            }
        }

        public List<Post> getThreadPosts(BlogThread thread)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Where(p => p.ThreadId == thread.BlogThreadId).ToList();
            }
        }
    }
}
