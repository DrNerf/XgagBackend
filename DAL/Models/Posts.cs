using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostOfTheDays = new HashSet<PostOfTheDay>();
            Votes = new HashSet<Vote>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ImageImageId { get; set; }
        public string OwnerId { get; set; }
        public string YouTubeLink { get; set; }
        public bool? IsNsfw { get; set; }

        public virtual Image ImageImage { get; set; }
        public virtual AspNetUser Owner { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostOfTheDay> PostOfTheDays { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
