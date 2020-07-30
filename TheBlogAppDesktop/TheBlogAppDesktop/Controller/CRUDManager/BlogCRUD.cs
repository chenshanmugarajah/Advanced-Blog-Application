using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public partial class CRUDManager
    {
        public void createBlog(string title, string description)
        {
            Blog blog;
            using (var db = new BloggingContext())
            {
                ChennitUser cu = db.ChennitUsers.Where(cu => cu.Email == CurrentUser.Email).First();
                blog = new Blog
                {
                    Title = title,
                    Description = description
                };
                cu.Blogs.Add(blog);
                db.SaveChanges();
            }
            //createPost(blog.BlogId, $"Welcome to the {title} blog", "Begin blogging today!");
        }
        public List<Blog> getAllBlogs()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }

        public List<Blog> getUserBlog(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Where(b => b.ChennitUserId == id).ToList();
            }
        }
        public void updateBlog(int blogid, string title, string description)
        {
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Where(b => b.BlogId == blogid).FirstOrDefault();
                blog.Title = title;
                blog.Description = description;
                db.SaveChanges();
            }
        }
    }
}
