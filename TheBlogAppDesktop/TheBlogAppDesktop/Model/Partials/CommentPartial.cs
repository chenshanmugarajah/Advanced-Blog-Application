using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class Comment
    {
        public override string ToString()
        {
            using (var db = new BloggingContext())
            {
                var cu = db.ChennitUsers.Where(cu => cu.ChennitUserId == ChennitUserId).First();
                return $"{cu.Username} said: {CommentContent}";
            }
        }
    }
}
