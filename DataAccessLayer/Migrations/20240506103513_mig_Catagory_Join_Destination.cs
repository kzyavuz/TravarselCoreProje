using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_Catagory_Join_Destination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryCategoryID",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CatagoryCategoryID",
                table: "Destinations",
                column: "CatagoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Catagories_CatagoryCategoryID",
                table: "Destinations",
                column: "CatagoryCategoryID",
                principalTable: "Catagories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Catagories_CatagoryCategoryID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CatagoryCategoryID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CatagoryCategoryID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Destinations");
        }
    }
}
