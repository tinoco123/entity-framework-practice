using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("24d8f5ca-2451-463d-9ead-db339b16af4e"), null, "Universidad", 50 },
                    { new Guid("7ab81c93-7b17-43b1-9557-ec31ae80fa71"), "Canciones del grupo de alabanza", "Grupo de alabanza", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TaskId", "CategoriaId", "DateCreated", "Deadline", "Description", "PrioridadTarea", "Title" },
                values: new object[,]
                {
                    { new Guid("633e026b-489e-4960-bd01-ed5736ab1b6c"), new Guid("7ab81c93-7b17-43b1-9557-ec31ae80fa71"), new DateTime(2023, 4, 17, 23, 44, 24, 830, DateTimeKind.Local).AddTicks(1568), new DateTime(2023, 4, 18, 15, 30, 0, 0, DateTimeKind.Unspecified), null, 2, "Mandar canciones para el domingo" },
                    { new Guid("b35e2399-5842-4199-bf75-26511adde087"), new Guid("24d8f5ca-2451-463d-9ead-db339b16af4e"), new DateTime(2023, 4, 17, 23, 44, 24, 830, DateTimeKind.Local).AddTicks(1551), new DateTime(2023, 4, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), null, 2, "Estudiar diagramas de clase" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("633e026b-489e-4960-bd01-ed5736ab1b6c"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("b35e2399-5842-4199-bf75-26511adde087"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("24d8f5ca-2451-463d-9ead-db339b16af4e"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("7ab81c93-7b17-43b1-9557-ec31ae80fa71"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
