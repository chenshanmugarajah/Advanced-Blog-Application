using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int ChennitUserId { get; set; }
        public ChennitUser ChennitUser { get; set; }
    }
}
