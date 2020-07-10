using Microsoft.EntityFrameworkCore.Migrations;

namespace XirgoTest.Infrastructure.Persistence.Migrations
{
    public partial class addedConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "Vechiles",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Vechiles",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "VechileDetails",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "VechileDetails",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "VechileDetails",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "Vechiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "Vechiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "VechileDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "VechileDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "VechileDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "((0))");
        }
    }
}
