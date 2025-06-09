using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medhelp.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class MedicineDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");
        }
    }
}
