using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Comment
    {
        public Comment()
        {
            InverseParentComment = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateTimePosted { get; set; }
        public int? ParentCommentId { get; set; }
        public string OwnerId { get; set; }
        public int? PostOwnerPostId { get; set; }

        public AspNetUser Owner { get; set; }
        public Comment ParentComment { get; set; }
        public Post PostOwnerPost { get; set; }
        public ICollection<Comment> InverseParentComment { get; set; }
    }
}
