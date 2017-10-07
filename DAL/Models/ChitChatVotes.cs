using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class ChitChatVote
    {
        public int ChitChatVoteId { get; set; }
        public int VoteType { get; set; }
        public int? ChitChatChitChatId { get; set; }
        public string VoterId { get; set; }

        public ChitChat ChitChatChitChat { get; set; }
        public AspNetUser Voter { get; set; }
    }
}
