﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerBackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCreated = table.Column<bool>(type: "bit", nullable: true),
                    joinDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoardInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    BoardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BoardInfo_UserInfo_UserModelID",
                        column: x => x.UserModelID,
                        principalTable: "UserInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PostInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssigneeID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BoardModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostInfo_BoardInfo_BoardModelID",
                        column: x => x.BoardModelID,
                        principalTable: "BoardInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CommentInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentInfo_PostInfo_PostModelID",
                        column: x => x.PostModelID,
                        principalTable: "PostInfo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CommentReplyDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID = table.Column<int>(type: "int", nullable: true),
                    UsersID = table.Column<int>(type: "int", nullable: true),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentReplyDTOID = table.Column<int>(type: "int", nullable: true),
                    CommentsModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReplyDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentReplyDTO_CommentInfo_CommentsModelID",
                        column: x => x.CommentsModelID,
                        principalTable: "CommentInfo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CommentReplyDTO_CommentReplyDTO_CommentReplyDTOID",
                        column: x => x.CommentReplyDTOID,
                        principalTable: "CommentReplyDTO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardInfo_UserModelID",
                table: "BoardInfo",
                column: "UserModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentInfo_PostModelID",
                table: "CommentInfo",
                column: "PostModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplyDTO_CommentReplyDTOID",
                table: "CommentReplyDTO",
                column: "CommentReplyDTOID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplyDTO_CommentsModelID",
                table: "CommentReplyDTO",
                column: "CommentsModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PostInfo_BoardModelID",
                table: "PostInfo",
                column: "BoardModelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInfo");

            migrationBuilder.DropTable(
                name: "CommentReplyDTO");

            migrationBuilder.DropTable(
                name: "CommentInfo");

            migrationBuilder.DropTable(
                name: "PostInfo");

            migrationBuilder.DropTable(
                name: "BoardInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
