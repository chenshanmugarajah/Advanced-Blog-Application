using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class Blog
    {
        public override string ToString()
        {
            using (var db = new BloggingContext())
            {
                string owner = db.ChennitUsers.Where(cu => cu.ChennitUserId == ChennitUserId).First().Username;
                return $"{Title.ToUpper()}\n By: {owner.ToUpper()}";
            }
        }
    }
}
