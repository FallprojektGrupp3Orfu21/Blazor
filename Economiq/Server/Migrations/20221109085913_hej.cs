using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Economiq.Server.Migrations
{
    public partial class hej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "ExpensesCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2022, 11, 9, 9, 59, 13, 185, DateTimeKind.Local).AddTicks(2065));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "CreationDate", "ExpenseDate", "RecipientId", "UserId" },
                values: new object[] { 1, 25m, null, 2, "Glass", new DateTime(2022, 10, 11, 13, 58, 24, 244, DateTimeKind.Local).AddTicks(4764), new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), null, 1 });

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
