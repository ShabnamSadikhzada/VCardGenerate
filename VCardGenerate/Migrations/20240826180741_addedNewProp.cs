using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VCardGenerate.Migrations
{
    /// <inheritdoc />
    public partial class addedNewProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrUrl",
                table: "VCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrUrl",
                table: "VCards");
        }
    }
}
