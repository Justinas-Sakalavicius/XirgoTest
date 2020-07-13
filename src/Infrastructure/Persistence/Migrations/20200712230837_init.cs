using Microsoft.EntityFrameworkCore.Migrations;

namespace XirgoTest.Infrastructure.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 6, nullable: false),
                    BrandName = table.Column<string>(maxLength: 40, nullable: false),
                    ModelName = table.Column<string>(maxLength: 40, nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(nullable: false, defaultValueSql: "((0))"),
                    Longitude = table.Column<double>(nullable: false, defaultValueSql: "((0))"),
                    Speed = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    VechileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesDetails_Vehicles_VechileId",
                        column: x => x.VechileId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDetails_VechileId",
                table: "VehiclesDetails",
                column: "VechileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesDetails");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
