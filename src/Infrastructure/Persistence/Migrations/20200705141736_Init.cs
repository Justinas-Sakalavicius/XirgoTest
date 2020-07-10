using Microsoft.EntityFrameworkCore.Migrations;

namespace XirgoTest.Infrastructure.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vechiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 6, nullable: false),
                    BrandName = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vechiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VechileDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    VechileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VechileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VechileDetails_Vechiles_VechileId",
                        column: x => x.VechileId,
                        principalTable: "Vechiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VechileDetails_VechileId",
                table: "VechileDetails",
                column: "VechileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VechileDetails");

            migrationBuilder.DropTable(
                name: "Vechiles");
        }
    }
}
