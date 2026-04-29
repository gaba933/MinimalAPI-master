using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "perfil",
                table: "Administradors",
                newName: "Perfil");

            migrationBuilder.InsertData(
                table: "Administradors",
                columns: new[] { "Id", "Nome", "Perfil", "Senha" },
                values: new object[] { 1, "Administrador", "Adm", "123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administradors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Administradors",
                newName: "perfil");
        }
    }
}
