using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Image
    {
        public Image()
        {
            Posts = new HashSet<Post>();
        }

        public int ImageId { get; set; }
        public byte[] Data { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
