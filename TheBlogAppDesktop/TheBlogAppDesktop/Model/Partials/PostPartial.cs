﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public partial class Post
    {
        public override string ToString()
        {
            return $"Title: {Title}\nContent: {Content}\nLikes: {Likes}\n";
        }
    }
}
