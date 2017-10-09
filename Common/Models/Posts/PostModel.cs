using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public long DateCreatedTicks { get; set; }
        public string ImageUrl { get; set; }
        public string YouTubeLink { get; set; }
        public bool? IsNsfw { get; set; }
    }
}
