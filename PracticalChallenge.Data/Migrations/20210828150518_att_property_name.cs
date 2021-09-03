using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalChallenge.Data.Migrations
{
    public partial class att_property_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Produtos",
                newName: "ValorUnitario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorUnitario",
                table: "Produtos",
                newName: "Valor");
        }
    }
}
