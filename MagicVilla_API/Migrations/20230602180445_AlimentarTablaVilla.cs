using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    public partial class AlimentarTablaVilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 1, "", "Detalle de la villa...", new DateTime(2023, 6, 2, 12, 4, 45, 335, DateTimeKind.Local).AddTicks(9919), new DateTime(2023, 6, 2, 12, 4, 45, 335, DateTimeKind.Local).AddTicks(9910), "", 50, "Villa Real", 5, 200.0 });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 2, "", "Detalle de la villa...", new DateTime(2023, 6, 2, 12, 4, 45, 335, DateTimeKind.Local).AddTicks(9921), new DateTime(2023, 6, 2, 12, 4, 45, 335, DateTimeKind.Local).AddTicks(9921), "", 40, "Premium Vista de la Piscina", 4, 150.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
