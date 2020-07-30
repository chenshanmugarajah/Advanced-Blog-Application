using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }

        public int ChennitUserId { get; set; }
        public ChennitUser ChennitUser { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
