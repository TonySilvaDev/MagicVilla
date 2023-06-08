using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    public partial class UsuarioMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 8, 9, 2, 47, 428, DateTimeKind.Local).AddTicks(8300), new DateTime(2023, 6, 8, 9, 2, 47, 428, DateTimeKind.Local).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 8, 9, 2, 47, 428, DateTimeKind.Local).AddTicks(8302), new DateTime(2023, 6, 8, 9, 2, 47, 428, DateTimeKind.Local).AddTicks(8302) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 6, 16, 44, 55, 537, DateTimeKind.Local).AddTicks(3900), new DateTime(2023, 6, 6, 16, 44, 55, 537, DateTimeKind.Local).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 6, 16, 44, 55, 537, DateTimeKind.Local).AddTicks(3902), new DateTime(2023, 6, 6, 16, 44, 55, 537, DateTimeKind.Local).AddTicks(3902) });
        }
    }
}
