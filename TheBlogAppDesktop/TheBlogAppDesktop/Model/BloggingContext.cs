using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BloggingContext : DbContext
    {
        public DbSet<ChennitUser> ChennitUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<CurrentUser> CurrentUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=TheBlogApp;");
    }
}
