using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.PC.Contacts.Repository.Migrations
{
    public partial class addsubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SubCategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7c24fd27-34dd-4d51-b24f-e89b5f636b18"),
                column: "DateOfBirth",
                value: new DateTime(1984, 2, 19, 22, 0, 34, 95, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"),
                column: "DateOfBirth",
                value: new DateTime(2002, 2, 19, 22, 0, 34, 95, DateTimeKind.Local).AddTicks(5478));
        }
    }
}
