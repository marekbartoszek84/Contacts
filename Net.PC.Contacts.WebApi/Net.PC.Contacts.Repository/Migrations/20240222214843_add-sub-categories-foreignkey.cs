using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.PC.Contacts.Repository.Migrations
{
    public partial class addsubcategoriesforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7c24fd27-34dd-4d51-b24f-e89b5f636b18"),
                column: "DateOfBirth",
                value: new DateTime(1984, 2, 22, 22, 48, 43, 383, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"),
                column: "DateOfBirth",
                value: new DateTime(2002, 2, 22, 22, 48, 43, 383, DateTimeKind.Local).AddTicks(4589));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7c24fd27-34dd-4d51-b24f-e89b5f636b18"),
                column: "DateOfBirth",
                value: new DateTime(1984, 2, 20, 15, 0, 55, 914, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"),
                column: "DateOfBirth",
                value: new DateTime(2002, 2, 20, 15, 0, 55, 914, DateTimeKind.Local).AddTicks(783));
        }
    }
}
