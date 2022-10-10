using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Economiq.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensesCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => new { x.UserId, x.Mail });
                    table.ForeignKey(
                        name: "FK_Email_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategoryUser",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategoryUser", x => new { x.CategoriesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ExpenseCategoryUser_ExpensesCategory_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "ExpensesCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseCategoryUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_ExpensesCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpensesCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpensesCategory",
                columns: new[] { "Id", "CategoryName", "CreationDate" },
                values: new object[,]
                {
                    { 1, "Rent", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5330) },
                    { 2, "Food", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5334) },
                    { 3, "Transport", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5336) },
                    { 4, "Clothing", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5339) },
                    { 5, "Entertainment", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5341) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreationDate", "Fname", "Gender", "IsLoggedIn", "Lname", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5030), "Julia", "Female", false, "Hook", "Testing123", "JuliaH" },
                    { 2, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5077), "Alexander", "Male", false, "Volonen", "Testing234", "AlexV" },
                    { 3, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5080), "Stefan", "Male", false, "Krakowsky", "Testing345", "Peppo" },
                    { 4, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5083), "Winnie", "Female", false, "Huynh", "Testing456", "WinnieH" },
                    { 5, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5085), "Eric", "Male", false, "Flodin", "Testing567", "Ericx" },
                    { 6, "Fjugesta", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5088), "Anders", "Male", false, "Bergstrom", "Testing678", "AndersB" },
                    { 7, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5091), "Peter", "Male", false, "Hafid", "Testing789", "PeterH" },
                    { 8, "Orebro", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5094), "admin", "Male", false, "admin", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Email",
                columns: new[] { "Mail", "UserId" },
                values: new object[,]
                {
                    { "JuliaH@test.com", 1 },
                    { "AlexV@test.com", 2 },
                    { "Peppo@test.com", 3 },
                    { "WinnieH@test.com", 4 },
                    { "Ericx@test.com", 5 },
                    { "AndersB@test.com", 6 },
                    { "PeterH@test.com", 7 },
                    { "admin@admin.com", 8 }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategoryUser",
                columns: new[] { "CategoriesId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategoryUser",
                columns: new[] { "CategoriesId", "UsersId" },
                values: new object[] { 5, 7 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "Comment", "CreationDate", "ExpenseDate", "RecipientId", "UserId" },
                values: new object[] { 1, 25m, null, 2, "Glass", new DateTime(2022, 10, 10, 16, 15, 31, 80, DateTimeKind.Local).AddTicks(5458), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), null, 1 });

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "Id", "ExtraInfo", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "", "ICA", 1 },
                    { 2, "", "H&M", 5 },
                    { 3, "", "Alfred", 3 },
                    { 4, "", "Hanna", 4 },
                    { 5, "", "ICA", 7 },
                    { 6, "", "Coop", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategoryUser_UsersId",
                table: "ExpenseCategoryUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RecipientId",
                table: "Expenses",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_UserId",
                table: "Recipients",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "ExpenseCategoryUser");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "ExpensesCategory");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
