using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Economiq.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ExpenseDate" },
                values: new object[] { new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4122), new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2022, 10, 25, 15, 15, 15, 835, DateTimeKind.Local).AddTicks(3927));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "ExpenseDate" },
                values: new object[] { new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4764), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4585));
        }
    }
}
