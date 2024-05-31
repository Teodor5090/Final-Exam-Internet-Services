using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalExam.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cars_CarId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CarId",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_CarId",
                table: "Clients",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cars_CarId",
                table: "Clients",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
