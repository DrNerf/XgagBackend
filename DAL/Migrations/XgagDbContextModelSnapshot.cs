﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.Migrations
{
    [DbContext(typeof(XgagDbContext))]
    partial class XgagDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("DAL.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount");

                    b.Property<Guid?>("ApiSessionToken");

                    b.Property<string>("Browser");

                    b.Property<string>("BrowserVersion");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Ipaddress")
                        .HasColumnName("IPAddress");

                    b.Property<bool?>("IsActivated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsSubscribedForComments")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsSubscribedForNewPosts")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Platform");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('~/Content/Images/profile.svg')");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Trace");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DAL.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("DAL.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("LoginProvider", "ProviderKey", "UserId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("DAL.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .HasName("IX_RoleId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("DAL.ChitChat", b =>
                {
                    b.Property<int>("ChitChatId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("DangerType");

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                    b.HasKey("ChitChatId");

                    b.ToTable("ChitChats");
                });

            modelBuilder.Entity("DAL.ChitChatVote", b =>
                {
                    b.Property<int>("ChitChatVoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChitChatChitChatId")
                        .HasColumnName("ChitChat_ChitChatId");

                    b.Property<int>("VoteType");

                    b.Property<string>("VoterId")
                        .HasColumnName("Voter_Id")
                        .HasMaxLength(128);

                    b.HasKey("ChitChatVoteId");

                    b.HasIndex("ChitChatChitChatId")
                        .HasName("IX_ChitChat_ChitChatId");

                    b.HasIndex("VoterId")
                        .HasName("IX_Voter_Id");

                    b.ToTable("ChitChatVotes");
                });

            modelBuilder.Entity("DAL.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTimePosted")
                        .HasColumnType("datetime");

                    b.Property<string>("OwnerId")
                        .HasColumnName("Owner_Id")
                        .HasMaxLength(128);

                    b.Property<int?>("ParentCommentId")
                        .HasColumnName("Parent_CommentId");

                    b.Property<int?>("PostOwnerPostId")
                        .HasColumnName("PostOwner_PostId");

                    b.Property<string>("Text");

                    b.HasKey("CommentId");

                    b.HasIndex("OwnerId")
                        .HasName("IX_Owner_Id");

                    b.HasIndex("ParentCommentId")
                        .HasName("IX_Parent_CommentId");

                    b.HasIndex("PostOwnerPostId")
                        .HasName("IX_PostOwner_PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DAL.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.HasKey("ImageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DAL.People", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DownExperience")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("FirstName");

                    b.Property<string>("Image");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("LastName");

                    b.Property<int>("UpExperience")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DAL.PersonRank", b =>
                {
                    b.Property<int>("PersonRankId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceGain")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("PersonPersonId")
                        .HasColumnName("Person_PersonId");

                    b.Property<int>("Rank");

                    b.Property<int>("RankType");

                    b.Property<int>("Score")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("PersonRankId");

                    b.HasIndex("PersonPersonId")
                        .HasName("IX_Person_PersonId");

                    b.ToTable("PersonRanks");
                });

            modelBuilder.Entity("DAL.PersonVote", b =>
                {
                    b.Property<int>("PersonVoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PersonPersonId")
                        .HasColumnName("Person_PersonId");

                    b.Property<int>("VoteType");

                    b.HasKey("PersonVoteId");

                    b.HasIndex("PersonPersonId")
                        .HasName("IX_Person_PersonId");

                    b.ToTable("PersonVotes");
                });

            modelBuilder.Entity("DAL.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<int?>("ImageImageId")
                        .HasColumnName("Image_ImageId");

                    b.Property<bool?>("IsNsfw")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsNSFW")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("OwnerId")
                        .HasColumnName("Owner_Id")
                        .HasMaxLength(128);

                    b.Property<string>("Title");

                    b.Property<string>("YouTubeLink");

                    b.HasKey("PostId");

                    b.HasIndex("ImageImageId")
                        .HasName("IX_Image_ImageId");

                    b.HasIndex("OwnerId")
                        .HasName("IX_Owner_Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DAL.PostOfTheDay", b =>
                {
                    b.Property<int>("PostOfTheDayId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int?>("PostPostId")
                        .HasColumnName("Post_PostId");

                    b.HasKey("PostOfTheDayId");

                    b.HasIndex("PostPostId")
                        .HasName("IX_Post_PostId");

                    b.ToTable("PostOfTheDays");
                });

            modelBuilder.Entity("DAL.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnonymousAuthor");

                    b.Property<int?>("AuthorPersonId")
                        .HasColumnName("Author_PersonId");

                    b.Property<DateTime>("DateTimeCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("('1900-01-01T00:00:00.000')");

                    b.Property<string>("OwnerId")
                        .HasColumnName("Owner_Id")
                        .HasMaxLength(128);

                    b.Property<int>("QuoteType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Text");

                    b.HasKey("QuoteId");

                    b.HasIndex("AuthorPersonId")
                        .HasName("IX_Author_PersonId");

                    b.HasIndex("OwnerId")
                        .HasName("IX_Owner_Id");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("DAL.RankingHistoryItem", b =>
                {
                    b.Property<int>("PersonRankingHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("RankingDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("PersonRankingHistoryId");

                    b.ToTable("RankingHistoryItems");
                });

            modelBuilder.Entity("DAL.UserDailyVote", b =>
                {
                    b.Property<int>("UserDailyVoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId")
                        .HasColumnName("User_Id")
                        .HasMaxLength(128);

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime");

                    b.Property<int>("VoteType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.HasKey("UserDailyVoteId");

                    b.HasIndex("UserId")
                        .HasName("IX_User_Id");

                    b.ToTable("UserDailyVotes");
                });

            modelBuilder.Entity("DAL.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PostPostId")
                        .HasColumnName("Post_PostId");

                    b.Property<int>("Type");

                    b.Property<string>("VoterId")
                        .HasColumnName("Voter_Id")
                        .HasMaxLength(128);

                    b.HasKey("VoteId");

                    b.HasIndex("PostPostId")
                        .HasName("IX_Post_PostId");

                    b.HasIndex("VoterId")
                        .HasName("IX_Voter_Id");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("DAL.AspNetUserClaim", b =>
                {
                    b.HasOne("DAL.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.AspNetUserLogin", b =>
                {
                    b.HasOne("DAL.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.AspNetUserRole", b =>
                {
                    b.HasOne("DAL.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.ChitChatVote", b =>
                {
                    b.HasOne("DAL.ChitChat", "ChitChatChitChat")
                        .WithMany("ChitChatVotes")
                        .HasForeignKey("ChitChatChitChatId")
                        .HasConstraintName("FK_dbo.ChitChatVotes_dbo.ChitChats_ChitChat_ChitChatId");

                    b.HasOne("DAL.AspNetUser", "Voter")
                        .WithMany("ChitChatVotes")
                        .HasForeignKey("VoterId")
                        .HasConstraintName("FK_dbo.ChitChatVotes_dbo.AspNetUsers_Voter_Id");
                });

            modelBuilder.Entity("DAL.Comment", b =>
                {
                    b.HasOne("DAL.AspNetUser", "Owner")
                        .WithMany("Comments")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_dbo.Comments_dbo.AspNetUsers_Owner_Id");

                    b.HasOne("DAL.Comment", "ParentComment")
                        .WithMany("InverseParentComment")
                        .HasForeignKey("ParentCommentId")
                        .HasConstraintName("FK_dbo.Comments_dbo.Comments_Parent_CommentId");

                    b.HasOne("DAL.Post", "PostOwnerPost")
                        .WithMany("Comments")
                        .HasForeignKey("PostOwnerPostId")
                        .HasConstraintName("FK_dbo.Comments_dbo.Posts_PostOwner_PostId");
                });

            modelBuilder.Entity("DAL.PersonRank", b =>
                {
                    b.HasOne("DAL.People", "PersonPerson")
                        .WithMany("PersonRanks")
                        .HasForeignKey("PersonPersonId")
                        .HasConstraintName("FK_dbo.PersonRanks_dbo.People_Person_PersonId");
                });

            modelBuilder.Entity("DAL.PersonVote", b =>
                {
                    b.HasOne("DAL.People", "PersonPerson")
                        .WithMany("PersonVotes")
                        .HasForeignKey("PersonPersonId")
                        .HasConstraintName("FK_dbo.PersonVotes_dbo.People_Person_PersonId");
                });

            modelBuilder.Entity("DAL.Post", b =>
                {
                    b.HasOne("DAL.Image", "ImageImage")
                        .WithMany("Posts")
                        .HasForeignKey("ImageImageId")
                        .HasConstraintName("FK_dbo.Posts_dbo.Images_Image_ImageId");

                    b.HasOne("DAL.AspNetUser", "Owner")
                        .WithMany("Posts")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_dbo.Posts_dbo.AspNetUsers_Owner_Id");
                });

            modelBuilder.Entity("DAL.PostOfTheDay", b =>
                {
                    b.HasOne("DAL.Post", "PostPost")
                        .WithMany("PostOfTheDays")
                        .HasForeignKey("PostPostId")
                        .HasConstraintName("FK_dbo.PostOfTheDays_dbo.Posts_Post_PostId");
                });

            modelBuilder.Entity("DAL.Quote", b =>
                {
                    b.HasOne("DAL.People", "AuthorPerson")
                        .WithMany("Quotes")
                        .HasForeignKey("AuthorPersonId")
                        .HasConstraintName("FK_dbo.Quotes_dbo.People_Author_PersonId");

                    b.HasOne("DAL.AspNetUser", "Owner")
                        .WithMany("Quotes")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_dbo.Quotes_dbo.AspNetUsers_Owner_Id");
                });

            modelBuilder.Entity("DAL.UserDailyVote", b =>
                {
                    b.HasOne("DAL.AspNetUser", "User")
                        .WithMany("UserDailyVotes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.UserDailyVotes_dbo.AspNetUsers_User_Id");
                });

            modelBuilder.Entity("DAL.Vote", b =>
                {
                    b.HasOne("DAL.Post", "PostPost")
                        .WithMany("Votes")
                        .HasForeignKey("PostPostId")
                        .HasConstraintName("FK_dbo.Votes_dbo.Posts_Post_PostId");

                    b.HasOne("DAL.AspNetUser", "Voter")
                        .WithMany("Votes")
                        .HasForeignKey("VoterId")
                        .HasConstraintName("FK_dbo.Votes_dbo.AspNetUsers_Voter_Id");
                });
#pragma warning restore 612, 618
        }
    }
}