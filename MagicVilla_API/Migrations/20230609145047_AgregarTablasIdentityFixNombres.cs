using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    public partial class AgregarTablasIdentityFixNombres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 9, 8, 50, 47, 344, DateTimeKind.Local).AddTicks(8690), new DateTime(2023, 6, 9, 8, 50, 47, 344, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 9, 8, 50, 47, 344, DateTimeKind.Local).AddTicks(8692), new DateTime(2023, 6, 9, 8, 50, 47, 344, DateTimeKind.Local).AddTicks(8691) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 9, 8, 46, 30, 915, DateTimeKind.Local).AddTicks(4425), new DateTime(2023, 6, 9, 8, 46, 30, 915, DateTimeKind.Local).AddTicks(4414) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 6, 9, 8, 46, 30, 915, DateTimeKind.Local).AddTicks(4426), new DateTime(2023, 6, 9, 8, 46, 30, 915, DateTimeKind.Local).AddTicks(4426) });
        }
    }
}
