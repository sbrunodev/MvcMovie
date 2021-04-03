using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class Protocolo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProtocoloId",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Protocolo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPaciente = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocolo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protocolo_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProtocoloId",
                table: "Tarefa",
                column: "ProtocoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolo_PacienteId",
                table: "Protocolo",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Protocolo_ProtocoloId",
                table: "Tarefa",
                column: "ProtocoloId",
                principalTable: "Protocolo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Protocolo_ProtocoloId",
                table: "Tarefa");

            migrationBuilder.DropTable(
                name: "Protocolo");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ProtocoloId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ProtocoloId",
                table: "Tarefa");
        }
    }
}
