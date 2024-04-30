using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RezervationJoinDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationID",
                table: "Rezarvations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rezarvations_DestinationID",
                table: "Rezarvations",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezarvations_Destinations_DestinationID",
                table: "Rezarvations",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezarvations_Destinations_DestinationID",
                table: "Rezarvations");

            migrationBuilder.DropIndex(
                name: "IX_Rezarvations_DestinationID",
                table: "Rezarvations");

            migrationBuilder.DropColumn(
                name: "DestinationID",
                table: "Rezarvations");
        }
    }
}
