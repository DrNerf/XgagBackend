using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class PersonVote
    {
        public int PersonVoteId { get; set; }
        public int VoteType { get; set; }
        public int? PersonPersonId { get; set; }

        public People PersonPerson { get; set; }
    }
}
