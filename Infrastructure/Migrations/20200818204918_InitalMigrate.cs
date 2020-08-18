using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AiuHubServer.Infrastructure.Migrations
{
    public partial class InitalMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsAndAnnouncement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true),
                    VideoLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsAndAnnouncement", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsAndAnnouncement");
        }
    }
}
