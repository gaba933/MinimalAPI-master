using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class NomeForEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Administradors",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Administradors",
                newName: "Nome");
        }
    }
}
