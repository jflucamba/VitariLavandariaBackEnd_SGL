using Microsoft.EntityFrameworkCore.Migrations;

namespace VL.Data.Migrations
{
    public partial class alterarcampotbestadoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "EstadoPedidos",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "EstadoPedidos",
                newName: "Nome");
        }
    }
}
