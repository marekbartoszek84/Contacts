using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.PC.Contacts.Repository.Migrations
{
    public partial class addcontacts_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("7c24fd27-34dd-4d51-b24f-e89b5f636b18"), new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"), new DateTime(1984, 2, 19, 22, 0, 34, 95, DateTimeKind.Local).AddTicks(5530), "bakala@wp.pl", "Faris", "Bakala", "gjsdgjdsg", "600706500" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"), new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"), new DateTime(2002, 2, 19, 22, 0, 34, 95, DateTimeKind.Local).AddTicks(5478), "ted@wp.pl", "Ted", "Buzz", "1234", "700700700" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7c24fd27-34dd-4d51-b24f-e89b5f636b18"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7"));
        }
    }
}
