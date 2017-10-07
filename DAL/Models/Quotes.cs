using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public string Text { get; set; }
        public int? AuthorPersonId { get; set; }
        public string OwnerId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string AnonymousAuthor { get; set; }
        public int QuoteType { get; set; }

        public People AuthorPerson { get; set; }
        public AspNetUser Owner { get; set; }
    }
}
