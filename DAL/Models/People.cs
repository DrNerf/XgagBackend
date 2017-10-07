using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class People
    {
        public People()
        {
            PersonRanks = new HashSet<PersonRank>();
            PersonVotes = new HashSet<PersonVote>();
            Quotes = new HashSet<Quote>();
        }

        public int PersonId { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DownExperience { get; set; }
        public int UpExperience { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<PersonRank> PersonRanks { get; set; }
        public ICollection<PersonVote> PersonVotes { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
