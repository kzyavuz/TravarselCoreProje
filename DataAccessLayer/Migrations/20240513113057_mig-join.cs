using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migjoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryID",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CatagoryID",
                table: "Destinations",
                column: "CatagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Catagories_CatagoryID",
                table: "Destinations",
                column: "CatagoryID",
                principalTable: "Catagories",
                principalColumn: "CatagoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Catagories_CatagoryID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CatagoryID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CatagoryID",
                table: "Destinations");
        }
    }
}
