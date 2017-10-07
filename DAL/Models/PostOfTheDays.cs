using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class PostOfTheDay
    {
        public int PostOfTheDayId { get; set; }
        public DateTime Date { get; set; }
        public int? PostPostId { get; set; }

        public Post PostPost { get; set; }
    }
}
