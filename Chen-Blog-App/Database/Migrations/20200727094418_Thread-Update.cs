using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ThreadUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThreadName",
                table: "BlogThreads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreadName",
                table: "BlogThreads");
        }
    }
}
