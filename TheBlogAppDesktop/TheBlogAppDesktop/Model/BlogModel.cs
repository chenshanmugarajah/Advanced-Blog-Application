using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ChennitUserId { get; set; }
        public ChennitUser ChennitUser { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}
