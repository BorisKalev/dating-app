using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjFinRBEM.Migrations
{
    /// <inheritdoc />
    public partial class NomDeLaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "ProfileImage",
        table: "User",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "User",
                nullable: true,  // Permet les valeurs NULL
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
    name: "ProfileImage",
    table: "User",
    nullable: true,
    oldClrType: typeof(string),
    oldType: "nvarchar(max)");

        }
    }
}
