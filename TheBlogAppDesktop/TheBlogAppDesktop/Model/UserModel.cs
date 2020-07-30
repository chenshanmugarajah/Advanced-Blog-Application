using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ChennitUser
    {
        public int ChennitUserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
        public List<Blog> Blogs { get; } = new List<Blog>();
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
