using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_update_destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details3",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details4",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details5",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsTitle1",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsTitle2",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsTitle3",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsTitle4",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailsTitle5",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details3",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Details4",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Details5",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DetailsTitle1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DetailsTitle2",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DetailsTitle3",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DetailsTitle4",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DetailsTitle5",
                table: "Destinations");
        }
    }
}
