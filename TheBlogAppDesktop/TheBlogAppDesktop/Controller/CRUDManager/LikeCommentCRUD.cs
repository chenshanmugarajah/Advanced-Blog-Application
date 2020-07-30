using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public partial class CRUDManager
    {
        public void likePost(int postid)
        {
            using (var db = new BloggingContext())
            {
                Post post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault();
                post.Likes = post.Likes + 1;
                db.SaveChanges();
            }
        }
        public void createComment(int postid, string comment)
        {
            using (var db = new BloggingContext())
            {
                Post post = db.Posts.Where(p => p.PostId == postid).FirstOrDefault();
                post.Comments.Add(
                    new Comment
                    {
                        CommentContent = comment
                    });
                db.SaveChanges();
            }
        }
        public List<Comment> getAllComments()
        {
            using (var db = new BloggingContext())
            {
                return db.Comments.ToList();
            }
        }
        public List<Comment> getPostComments(int postId)
        {
            using (var db = new BloggingContext())
            {
                return db.Comments.Where(c => c.PostId == postId).ToList();
            }
        }
    }
}
