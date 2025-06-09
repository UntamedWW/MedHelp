using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medhelp.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class ParsedElementsCounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParsedElementsCounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false),
                    LastPage = table.Column<int>(type: "integer", nullable: false),
                    LastElementNumber = table.Column<int>(type: "integer", nullable: false),
                    IsEnded = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedElementsCounters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedElementsCounters");
        }
    }
}
