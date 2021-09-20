using Microsoft.EntityFrameworkCore.Migrations;

namespace Emaritna.DAL.Migrations
{
    public partial class addsomefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "UserType",
                schema: "dbo",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "dbo",
                table: "AspNetUsers");
        }
    }
}
