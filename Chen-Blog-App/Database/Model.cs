using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class BloggingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Chen-Blog-App;");
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passowrd { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
        public List<Thread> Threads { get; } = new List<Thread>();

    }

    public class Thread
    {
        public int ThreadId { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public List<Post> Posts { get; } = new List<Post>();

        public int UserId { get; set; }
        public User User { get; set; }

    }

    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ThreadId { get; set; }
        public Thread Thread { get; set; }

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
