using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroRotasRepository.Migrations
{
    /// <inheritdoc />
    public partial class InitProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rota",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    custo = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rota", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rota");
        }
    }
}
