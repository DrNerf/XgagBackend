using System.Collections.Generic;

namespace Common
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        public double DateTimePostedTicks { get; set; }

        public UserModel Owner { get; set; }

        public IEnumerable<CommentModel> SubComments { get; set; }
    }
}
