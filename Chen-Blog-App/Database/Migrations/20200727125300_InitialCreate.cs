using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogUsers",
                columns: table => new
                {
                    BlogUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Passowrd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogUsers", x => x.BlogUserId);
                });

            migrationBuilder.CreateTable(
                name: "CurrentUsers",
                columns: table => new
                {
                    CurrentUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Passowrd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentUsers", x => x.CurrentUserId);
                });

            migrationBuilder.CreateTable(
                name: "BlogThreads",
                columns: table => new
                {
                    BlogThreadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    BlogUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogThreads", x => x.BlogThreadId);
                    table.ForeignKey(
                        name: "FK_BlogThreads_BlogUsers_BlogUserId",
                        column: x => x.BlogUserId,
                        principalTable: "BlogUsers",
                        principalColumn: "BlogUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(nullable: true),
                    PostContent = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    BlogUserId = table.Column<int>(nullable: false),
                    ThreadId = table.Column<int>(nullable: false),
                    BlogThreadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_BlogThreads_BlogThreadId",
                        column: x => x.BlogThreadId,
                        principalTable: "BlogThreads",
                        principalColumn: "BlogThreadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_BlogUsers_BlogUserId",
                        column: x => x.BlogUserId,
                        principalTable: "BlogUsers",
                        principalColumn: "BlogUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostComment = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogThreads_BlogUserId",
                table: "BlogThreads",
                column: "BlogUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogThreadId",
                table: "Posts",
                column: "BlogThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogUserId",
                table: "Posts",
                column: "BlogUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CurrentUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "BlogThreads");

            migrationBuilder.DropTable(
                name: "BlogUsers");
        }
    }
}
