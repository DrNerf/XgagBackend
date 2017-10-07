﻿using System;
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

        public Image ImageImage { get; set; }
        public AspNetUser Owner { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostOfTheDay> PostOfTheDays { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
