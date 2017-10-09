using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ApiSessionToken = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsSubscribedForComments = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    IsSubscribedForNewPosts = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('~/Content/Images/profile.svg')"),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChitChats",
                columns: table => new
                {
                    ChitChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DangerType = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('1900-01-01T00:00:00.000')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitChats", x => x.ChitChatId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DownExperience = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpExperience = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "RankingHistoryItems",
                columns: table => new
                {
                    PersonRankingHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RankingDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingHistoryItems", x => x.PersonRankingHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDailyVotes",
                columns: table => new
                {
                    UserDailyVoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    VoteDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDailyVotes", x => x.UserDailyVoteId);
                    table.ForeignKey(
                        name: "FK_dbo.UserDailyVotes_dbo.AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChitChatVotes",
                columns: table => new
                {
                    ChitChatVoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChitChat_ChitChatId = table.Column<int>(type: "int", nullable: true),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    Voter_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitChatVotes", x => x.ChitChatVoteId);
                    table.ForeignKey(
                        name: "FK_dbo.ChitChatVotes_dbo.ChitChats_ChitChat_ChitChatId",
                        column: x => x.ChitChat_ChitChatId,
                        principalTable: "ChitChats",
                        principalColumn: "ChitChatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.ChitChatVotes_dbo.AspNetUsers_Voter_Id",
                        column: x => x.Voter_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image_ImageId = table.Column<int>(type: "int", nullable: true),
                    IsNSFW = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Owner_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_dbo.Posts_dbo.Images_Image_ImageId",
                        column: x => x.Image_ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Posts_dbo.AspNetUsers_Owner_Id",
                        column: x => x.Owner_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonRanks",
                columns: table => new
                {
                    PersonRankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExperienceGain = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Person_PersonId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    RankType = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRanks", x => x.PersonRankId);
                    table.ForeignKey(
                        name: "FK_dbo.PersonRanks_dbo.People_Person_PersonId",
                        column: x => x.Person_PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonVotes",
                columns: table => new
                {
                    PersonVoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Person_PersonId = table.Column<int>(type: "int", nullable: true),
                    VoteType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVotes", x => x.PersonVoteId);
                    table.ForeignKey(
                        name: "FK_dbo.PersonVotes_dbo.People_Person_PersonId",
                        column: x => x.Person_PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnonymousAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author_PersonId = table.Column<int>(type: "int", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('1900-01-01T00:00:00.000')"),
                    Owner_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    QuoteType = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_dbo.Quotes_dbo.People_Author_PersonId",
                        column: x => x.Author_PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Quotes_dbo.AspNetUsers_Owner_Id",
                        column: x => x.Owner_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTimePosted = table.Column<DateTime>(type: "datetime", nullable: false),
                    Owner_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Parent_CommentId = table.Column<int>(type: "int", nullable: true),
                    PostOwner_PostId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_dbo.Comments_dbo.AspNetUsers_Owner_Id",
                        column: x => x.Owner_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Comments_dbo.Comments_Parent_CommentId",
                        column: x => x.Parent_CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Comments_dbo.Posts_PostOwner_PostId",
                        column: x => x.PostOwner_PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostOfTheDays",
                columns: table => new
                {
                    PostOfTheDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Post_PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOfTheDays", x => x.PostOfTheDayId);
                    table.ForeignKey(
                        name: "FK_dbo.PostOfTheDays_dbo.Posts_Post_PostId",
                        column: x => x.Post_PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Post_PostId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Voter_Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_dbo.Votes_dbo.Posts_Post_PostId",
                        column: x => x.Post_PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.Votes_dbo.AspNetUsers_Voter_Id",
                        column: x => x.Voter_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChitChat_ChitChatId",
                table: "ChitChatVotes",
                column: "ChitChat_ChitChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_Id",
                table: "ChitChatVotes",
                column: "Voter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_Id",
                table: "Comments",
                column: "Owner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_CommentId",
                table: "Comments",
                column: "Parent_CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOwner_PostId",
                table: "Comments",
                column: "PostOwner_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId",
                table: "PersonRanks",
                column: "Person_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonId",
                table: "PersonVotes",
                column: "Person_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId",
                table: "PostOfTheDays",
                column: "Post_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageId",
                table: "Posts",
                column: "Image_ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_Id",
                table: "Posts",
                column: "Owner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Author_PersonId",
                table: "Quotes",
                column: "Author_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_Id",
                table: "Quotes",
                column: "Owner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "UserDailyVotes",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId",
                table: "Votes",
                column: "Post_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Voter_Id",
                table: "Votes",
                column: "Voter_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "ChitChatVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PersonRanks");

            migrationBuilder.DropTable(
                name: "PersonVotes");

            migrationBuilder.DropTable(
                name: "PostOfTheDays");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "RankingHistoryItems");

            migrationBuilder.DropTable(
                name: "UserDailyVotes");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChitChats");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
