using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountriesEF_HW.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearFounded = table.Column<long>(type: "bigint", nullable: false),
                    GovernmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    Area = table.Column<long>(type: "bigint", nullable: false),
                    GDP = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
