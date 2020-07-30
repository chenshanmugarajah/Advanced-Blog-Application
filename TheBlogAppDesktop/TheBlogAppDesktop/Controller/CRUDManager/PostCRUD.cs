using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public partial class CRUDManager
    {
        public void createPost(int blogid, string title, string content)
        {
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Where(b => b.BlogId == blogid).First();

                blog.Posts.Add(
                    new Post
                    {
                        Title = title,
                        Content = content,
                        Likes = 0
                    });
                db.SaveChanges();
            }
        }
        public List<Post> getAllPosts()
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.ToList();
            }
        }
        public List<Post> getBlogPosts(int id)
        {
            using (var db = new BloggingContext())
            {
                var posts = db.Posts.Where(p => p.BlogId == id).ToList();
                return posts;
            }
        }

        public List<Post> getUserPosts(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Where(p => p.ChennitUserId == id).ToList();
            }
        }

        public void updatePost(int postid, string title, string content)
        {
            using (var db = new BloggingContext())
            {
                Post post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault();
                post.Title = title;
                post.Content = content;
                db.SaveChanges();
            }
        }
        public void deletePost(int postid)
        {
            using (var db = new BloggingContext())
            {
                Post post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault();
                db.Remove(post);
                db.SaveChanges();
            }
        }
    }
}
