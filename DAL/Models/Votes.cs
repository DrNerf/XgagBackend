using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int Type { get; set; }
        public int? PostPostId { get; set; }
        public string VoterId { get; set; }

        public Post PostPost { get; set; }
        public AspNetUser Voter { get; set; }
    }
}
