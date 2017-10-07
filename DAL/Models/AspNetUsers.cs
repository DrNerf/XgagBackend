using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            ChitChatVotes = new HashSet<ChitChatVote>();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            Quotes = new HashSet<Quote>();
            UserDailyVotes = new HashSet<UserDailyVote>();
            Votes = new HashSet<Vote>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public bool? IsSubscribedForNewPosts { get; set; }
        public bool? IsSubscribedForComments { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool? IsActivated { get; set; }
        public Guid? ApiSessionToken { get; set; }
        public string Trace { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Ipaddress { get; set; }

        public ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public ICollection<ChitChatVote> ChitChatVotes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        public ICollection<UserDailyVote> UserDailyVotes { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
