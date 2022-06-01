using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUbiqua.Migrations
{
    public partial class NamingFixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Utilizador",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Utilizador",
                newName: "password");
        }
    }
}
