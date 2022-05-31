using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUbiqua.Migrations
{
    public partial class InitialDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID_Sala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lotacao = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<float>(type: "real", nullable: false),
                    EstadoLuzes = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID_Sala);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    ID_Utilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUtilizador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_admin = table.Column<bool>(type: "bit", nullable: false),
                    Banido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.ID_Utilizador);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    ID_Sensor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaID_Sala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.ID_Sensor);
                    table.ForeignKey(
                        name: "FK_Sensor_Sala_SalaID_Sala",
                        column: x => x.SalaID_Sala,
                        principalTable: "Sala",
                        principalColumn: "ID_Sala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaUtilizador",
                columns: table => new
                {
                    SalasID_Sala = table.Column<int>(type: "int", nullable: false),
                    UtilizadoresID_Utilizador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaUtilizador", x => new { x.SalasID_Sala, x.UtilizadoresID_Utilizador });
                    table.ForeignKey(
                        name: "FK_SalaUtilizador_Sala_SalasID_Sala",
                        column: x => x.SalasID_Sala,
                        principalTable: "Sala",
                        principalColumn: "ID_Sala",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaUtilizador_Utilizador_UtilizadoresID_Utilizador",
                        column: x => x.UtilizadoresID_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaUtilizador_UtilizadoresID_Utilizador",
                table: "SalaUtilizador",
                column: "UtilizadoresID_Utilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_SalaID_Sala",
                table: "Sensor",
                column: "SalaID_Sala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaUtilizador");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
