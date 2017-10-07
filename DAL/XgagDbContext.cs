using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public partial class XgagDbContext : DbContext
    {
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ChitChat> ChitChats { get; set; }
        public virtual DbSet<ChitChatVote> ChitChatVotes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PersonRank> PersonRanks { get; set; }
        public virtual DbSet<PersonVote> PersonVotes { get; set; }
        public virtual DbSet<PostOfTheDay> PostOfTheDays { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<RankingHistoryItem> RankingHistoryItems { get; set; }
        public virtual DbSet<UserDailyVote> UserDailyVotes { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        public XgagDbContext(DbContextOptions<XgagDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSubscribedForComments).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSubscribedForNewPosts).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ProfilePictureUrl)
                    .IsRequired()
                    .HasDefaultValueSql("('~/Content/Images/profile.svg')");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ChitChat>(entity =>
            {
                entity.HasKey(e => e.ChitChatId);

                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");
            });

            modelBuilder.Entity<ChitChatVote>(entity =>
            {
                entity.HasKey(e => e.ChitChatVoteId);

                entity.HasIndex(e => e.ChitChatChitChatId)
                    .HasName("IX_ChitChat_ChitChatId");

                entity.HasIndex(e => e.VoterId)
                    .HasName("IX_Voter_Id");

                entity.Property(e => e.ChitChatChitChatId).HasColumnName("ChitChat_ChitChatId");

                entity.Property(e => e.VoterId)
                    .HasColumnName("Voter_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.ChitChatChitChat)
                    .WithMany(p => p.ChitChatVotes)
                    .HasForeignKey(d => d.ChitChatChitChatId)
                    .HasConstraintName("FK_dbo.ChitChatVotes_dbo.ChitChats_ChitChat_ChitChatId");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.ChitChatVotes)
                    .HasForeignKey(d => d.VoterId)
                    .HasConstraintName("FK_dbo.ChitChatVotes_dbo.AspNetUsers_Voter_Id");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasIndex(e => e.OwnerId)
                    .HasName("IX_Owner_Id");

                entity.HasIndex(e => e.ParentCommentId)
                    .HasName("IX_Parent_CommentId");

                entity.HasIndex(e => e.PostOwnerPostId)
                    .HasName("IX_PostOwner_PostId");

                entity.Property(e => e.DateTimePosted).HasColumnType("datetime");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("Owner_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.ParentCommentId).HasColumnName("Parent_CommentId");

                entity.Property(e => e.PostOwnerPostId).HasColumnName("PostOwner_PostId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_dbo.Comments_dbo.AspNetUsers_Owner_Id");

                entity.HasOne(d => d.ParentComment)
                    .WithMany(p => p.InverseParentComment)
                    .HasForeignKey(d => d.ParentCommentId)
                    .HasConstraintName("FK_dbo.Comments_dbo.Comments_Parent_CommentId");

                entity.HasOne(d => d.PostOwnerPost)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostOwnerPostId)
                    .HasConstraintName("FK_dbo.Comments_dbo.Posts_PostOwner_PostId");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId);
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.DownExperience).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpExperience).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PersonRank>(entity =>
            {
                entity.HasKey(e => e.PersonRankId);

                entity.HasIndex(e => e.PersonPersonId)
                    .HasName("IX_Person_PersonId");

                entity.Property(e => e.ExperienceGain).HasDefaultValueSql("((0))");

                entity.Property(e => e.PersonPersonId).HasColumnName("Person_PersonId");

                entity.Property(e => e.Score).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PersonPerson)
                    .WithMany(p => p.PersonRanks)
                    .HasForeignKey(d => d.PersonPersonId)
                    .HasConstraintName("FK_dbo.PersonRanks_dbo.People_Person_PersonId");
            });

            modelBuilder.Entity<PersonVote>(entity =>
            {
                entity.HasKey(e => e.PersonVoteId);

                entity.HasIndex(e => e.PersonPersonId)
                    .HasName("IX_Person_PersonId");

                entity.Property(e => e.PersonPersonId).HasColumnName("Person_PersonId");

                entity.HasOne(d => d.PersonPerson)
                    .WithMany(p => p.PersonVotes)
                    .HasForeignKey(d => d.PersonPersonId)
                    .HasConstraintName("FK_dbo.PersonVotes_dbo.People_Person_PersonId");
            });

            modelBuilder.Entity<PostOfTheDay>(entity =>
            {
                entity.HasKey(e => e.PostOfTheDayId);

                entity.HasIndex(e => e.PostPostId)
                    .HasName("IX_Post_PostId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.PostPostId).HasColumnName("Post_PostId");

                entity.HasOne(d => d.PostPost)
                    .WithMany(p => p.PostOfTheDays)
                    .HasForeignKey(d => d.PostPostId)
                    .HasConstraintName("FK_dbo.PostOfTheDays_dbo.Posts_Post_PostId");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.HasIndex(e => e.ImageImageId)
                    .HasName("IX_Image_ImageId");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("IX_Owner_Id");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ImageImageId).HasColumnName("Image_ImageId");

                entity.Property(e => e.IsNsfw)
                    .HasColumnName("IsNSFW")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("Owner_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.ImageImage)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ImageImageId)
                    .HasConstraintName("FK_dbo.Posts_dbo.Images_Image_ImageId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_dbo.Posts_dbo.AspNetUsers_Owner_Id");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(e => e.QuoteId);

                entity.HasIndex(e => e.AuthorPersonId)
                    .HasName("IX_Author_PersonId");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("IX_Owner_Id");

                entity.Property(e => e.AuthorPersonId).HasColumnName("Author_PersonId");

                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("Owner_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.QuoteType).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AuthorPerson)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.AuthorPersonId)
                    .HasConstraintName("FK_dbo.Quotes_dbo.People_Author_PersonId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_dbo.Quotes_dbo.AspNetUsers_Owner_Id");
            });

            modelBuilder.Entity<RankingHistoryItem>(entity =>
            {
                entity.HasKey(e => e.PersonRankingHistoryId);

                entity.Property(e => e.RankingDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserDailyVote>(entity =>
            {
                entity.HasKey(e => e.UserDailyVoteId);

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.VoteDate).HasColumnType("datetime");

                entity.Property(e => e.VoteType).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDailyVotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.UserDailyVotes_dbo.AspNetUsers_User_Id");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.VoteId);

                entity.HasIndex(e => e.PostPostId)
                    .HasName("IX_Post_PostId");

                entity.HasIndex(e => e.VoterId)
                    .HasName("IX_Voter_Id");

                entity.Property(e => e.PostPostId).HasColumnName("Post_PostId");

                entity.Property(e => e.VoterId)
                    .HasColumnName("Voter_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.PostPost)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.PostPostId)
                    .HasConstraintName("FK_dbo.Votes_dbo.Posts_Post_PostId");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.VoterId)
                    .HasConstraintName("FK_dbo.Votes_dbo.AspNetUsers_Voter_Id");
            });
        }
    }
}
