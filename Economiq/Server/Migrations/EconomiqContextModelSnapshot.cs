﻿// <auto-generated />
using System;
using Economiq.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Economiq.Server.Migrations
{
    [DbContext(typeof(EconomiqContext))]
    partial class EconomiqContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Economiq.Shared.Models.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Email", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "Mail");

                    b.ToTable("Email");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Mail = "JuliaH@test.com"
                        },
                        new
                        {
                            UserId = 2,
                            Mail = "AlexV@test.com"
                        },
                        new
                        {
                            UserId = 3,
                            Mail = "Peppo@test.com"
                        },
                        new
                        {
                            UserId = 4,
                            Mail = "WinnieH@test.com"
                        },
                        new
                        {
                            UserId = 5,
                            Mail = "Ericx@test.com"
                        },
                        new
                        {
                            UserId = 6,
                            Mail = "AndersB@test.com"
                        },
                        new
                        {
                            UserId = 7,
                            Mail = "PeterH@test.com"
                        },
                        new
                        {
                            UserId = 8,
                            Mail = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25m,
                            CategoryId = 2,
                            Comment = "Glass",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(331),
                            ExpenseDate = new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ExpensesCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Rent",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(280)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Food",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(284)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Transport",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(287)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Clothing",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(290)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Entertainment",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(292)
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExtraInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExtraInfo = "",
                            Name = "ICA",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExtraInfo = "",
                            Name = "H&M",
                            UserId = 5
                        },
                        new
                        {
                            Id = 3,
                            ExtraInfo = "",
                            Name = "Alfred",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            ExtraInfo = "",
                            Name = "Hanna",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            ExtraInfo = "",
                            Name = "ICA",
                            UserId = 7
                        },
                        new
                        {
                            Id = 6,
                            ExtraInfo = "",
                            Name = "Coop",
                            UserId = 7
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 87, DateTimeKind.Local).AddTicks(9977),
                            Fname = "Julia",
                            Gender = "Female",
                            IsLoggedIn = false,
                            Lname = "Hook",
                            Password = "Testing123",
                            UserName = "JuliaH"
                        },
                        new
                        {
                            Id = 2,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(20),
                            Fname = "Alexander",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Volonen",
                            Password = "Testing234",
                            UserName = "AlexV"
                        },
                        new
                        {
                            Id = 3,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(23),
                            Fname = "Stefan",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Krakowsky",
                            Password = "Testing345",
                            UserName = "Peppo"
                        },
                        new
                        {
                            Id = 4,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(26),
                            Fname = "Winnie",
                            Gender = "Female",
                            IsLoggedIn = false,
                            Lname = "Huynh",
                            Password = "Testing456",
                            UserName = "WinnieH"
                        },
                        new
                        {
                            Id = 5,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 6, 12, 31, 18, 255, DateTimeKind.Local).AddTicks(1943),
                            Fname = "Eric",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Flodin",
                            Password = "Testing567",
                            UserName = "Ericx"
                        },
                        new
                        {
                            Id = 6,
                            City = "Fjugesta",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(33),
                            Fname = "Anders",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Bergstrom",
                            Password = "Testing678",
                            UserName = "AndersB"
                        },
                        new
                        {
                            Id = 7,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(36),
                            Fname = "Peter",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Hafid",
                            Password = "Testing789",
                            UserName = "PeterH"
                        },
                        new
                        {
                            Id = 8,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 10, 7, 12, 5, 8, 88, DateTimeKind.Local).AddTicks(39),
                            Fname = "admin",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "admin",
                            Password = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ExpenseCategoryUser", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ExpenseCategoryUser");

                    b.HasData(
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 2
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 3
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 4
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 5
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 6
                        },
                        new
                        {
                            CategoriesId = 1,
                            UsersId = 7
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 1
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 2
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 3
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 4
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 5
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 6
                        },
                        new
                        {
                            CategoriesId = 2,
                            UsersId = 7
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 2
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 3
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 4
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 5
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 6
                        },
                        new
                        {
                            CategoriesId = 3,
                            UsersId = 7
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 1
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 2
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 3
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 4
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 5
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 6
                        },
                        new
                        {
                            CategoriesId = 4,
                            UsersId = 7
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 1
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 2
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 3
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 4
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 5
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 6
                        },
                        new
                        {
                            CategoriesId = 5,
                            UsersId = 7
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.Budget", b =>
                {
                    b.HasOne("Economiq.Shared.Models.User", "User")
                        .WithMany("Budgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Email", b =>
                {
                    b.HasOne("Economiq.Shared.Models.User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Expense", b =>
                {
                    b.HasOne("Economiq.Shared.Models.Budget", "Budget")
                        .WithMany("Expenses")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economiq.Shared.Models.ExpenseCategory", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economiq.Shared.Models.Recipient", "Recipient")
                        .WithMany("ExpenseNav")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economiq.Shared.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Category");

                    b.Navigation("Recipient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.HasOne("Economiq.Shared.Models.User", "User")
                        .WithMany("Recipients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpenseCategoryUser", b =>
                {
                    b.HasOne("Economiq.Shared.Models.ExpenseCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Economiq.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Economiq.Shared.Models.Budget", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Economiq.Shared.Models.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.Navigation("ExpenseNav");
                });

            modelBuilder.Entity("Economiq.Shared.Models.User", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Emails");

                    b.Navigation("Expenses");

                    b.Navigation("Recipients");
                });
#pragma warning restore 612, 618
        }
    }
}
