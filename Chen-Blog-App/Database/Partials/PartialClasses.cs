using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Database
{
    public partial class BlogThread
    {
        public override string ToString()
        {
            return $"{ThreadName}\n {Description}";
        }
    }

    public partial class Post
    {
        public override string ToString()
        {
            return $"{PostTitle}";
        }
    }
}
