using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class ChitChat
    {
        public ChitChat()
        {
            ChitChatVotes = new HashSet<ChitChatVote>();
        }

        public int ChitChatId { get; set; }
        public string Content { get; set; }
        public int DangerType { get; set; }
        public DateTime DateTimeCreated { get; set; }

        public ICollection<ChitChatVote> ChitChatVotes { get; set; }
    }
}
