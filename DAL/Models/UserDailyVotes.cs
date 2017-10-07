using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class UserDailyVote
    {
        public int UserDailyVoteId { get; set; }
        public DateTime VoteDate { get; set; }
        public string UserId { get; set; }
        public int VoteType { get; set; }

        public AspNetUser User { get; set; }
    }
}
