using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class PersonRank
    {
        public int PersonRankId { get; set; }
        public int Rank { get; set; }
        public int RankType { get; set; }
        public int? PersonPersonId { get; set; }
        public int Score { get; set; }
        public int ExperienceGain { get; set; }

        public People PersonPerson { get; set; }
    }
}
