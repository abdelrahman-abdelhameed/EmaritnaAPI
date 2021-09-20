using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emaritna.DAL.Migrations
{
    public partial class changeappartmentarct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TowerSection",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserApartments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ApartmentNumber = table.Column<string>(maxLength: 10, nullable: true),
                    TowerSection = table.Column<byte>(nullable: true),
                    FloorNumber = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApartments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserApartments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApartments_UserId",
                schema: "dbo",
                table: "UserApartments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserApartments",
                schema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                schema: "dbo",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TowerSection",
                schema: "dbo",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: true);
        }
    }
}
