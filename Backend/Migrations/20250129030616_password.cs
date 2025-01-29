using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Utilizador",
                type: "nvarchar(255)", // tipo de dado adequado para armazenar o hash da senha
                nullable: false, // você pode definir como false se a senha não puder ser nula
                defaultValue: string.Empty);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Utilizador");
        }
    }
}
