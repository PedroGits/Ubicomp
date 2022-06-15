using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUbiqua.Migrations
{
    public partial class Adicao_Estado_Sensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ligado",
                table: "Sensor",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ligado",
                table: "Sensor");
        }
    }
}
