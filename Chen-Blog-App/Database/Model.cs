using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class BloggingContext : DbContext
    {
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<BlogThread> BlogThreads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Chen-Blog-App;");
    }

    public class BlogUser
    {
        public int BlogUserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
        public List<BlogThread> BlogThreads { get; } = new List<BlogThread>();

    }

    public partial class BlogThread
    {
        public int BlogThreadId { get; set; }
        public string ThreadName { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public List<Post> Posts { get; } = new List<Post>();

        public int BlogUserId { get; set; }
        public BlogUser BlogUser { get; set; }

    }

    public partial class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }

        public int BlogUserId { get; set; }
        public BlogUser BlogUser { get; set; }

        public int ThreadId { get; set; }
        public BlogThread BlogThread { get; set; }

        public List<Comment> Comments { get; } = new List<Comment>();

    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string PostComment { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
