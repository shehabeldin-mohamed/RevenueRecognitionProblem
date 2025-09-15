using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevenueRecognitionProblem.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientTablesWithTPCInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ClientSequence");

            migrationBuilder.CreateTable(
                name: "CompanyClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Krs = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "IndividualClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ClientSequence]"),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualClients", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClients_Krs",
                table: "CompanyClients",
                column: "Krs",
                unique: true,
                filter: "[Krs] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualClients_Pesel",
                table: "IndividualClients",
                column: "Pesel",
                unique: true,
                filter: "[Pesel] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyClients");

            migrationBuilder.DropTable(
                name: "IndividualClients");

            migrationBuilder.DropSequence(
                name: "ClientSequence");
        }
    }
}
