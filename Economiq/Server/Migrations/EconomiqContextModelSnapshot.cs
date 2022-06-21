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

            modelBuilder.Entity("Economiq.Shared.Models.Email", b =>
                {
                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserNavId", "Mail");

                    b.ToTable("Email");

                    b.HasData(
                        new
                        {
                            UserNavId = 1,
                            Mail = "JuliaH@test.com"
                        },
                        new
                        {
                            UserNavId = 2,
                            Mail = "AlexV@test.com"
                        },
                        new
                        {
                            UserNavId = 3,
                            Mail = "Peppo@test.com"
                        },
                        new
                        {
                            UserNavId = 4,
                            Mail = "WinnieH@test.com"
                        },
                        new
                        {
                            UserNavId = 5,
                            Mail = "Ericx@test.com"
                        },
                        new
                        {
                            UserNavId = 6,
                            Mail = "AndersB@test.com"
                        },
                        new
                        {
                            UserNavId = 7,
                            Mail = "PeterH@test.com"
                        },
                        new
                        {
                            UserNavId = 8,
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

                    b.Property<int?>("CategoryNavId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecipientNavId")
                        .HasColumnType("int");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryNavId");

                    b.HasIndex("RecipientNavId");

                    b.HasIndex("UserNavId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25m,
                            CategoryNavId = 2,
                            Comment = "Glass",
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8142),
                            ExpenseDate = new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            UserNavId = 1
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8043)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Food",
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8051)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Transport",
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8056)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Clothing",
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8060)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Entertainment",
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(8064)
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserNavId");

                    b.ToTable("Recipients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Örebro",
                            Name = "ICA",
                            Street = "",
                            UserNavId = 1,
                            Zipcode = ""
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            Name = "H&M",
                            Street = "",
                            UserNavId = 5,
                            Zipcode = ""
                        },
                        new
                        {
                            Id = 3,
                            City = "Göteborg",
                            Name = "Alfred",
                            Street = "",
                            UserNavId = 3,
                            Zipcode = ""
                        },
                        new
                        {
                            Id = 4,
                            City = "Örebro",
                            Name = "Hanna",
                            Street = "",
                            UserNavId = 4,
                            Zipcode = ""
                        },
                        new
                        {
                            Id = 5,
                            City = "Nora",
                            Name = "ICA",
                            Street = "",
                            UserNavId = 7,
                            Zipcode = ""
                        },
                        new
                        {
                            Id = 6,
                            City = "Morgongåva",
                            Name = "Coop",
                            Street = "",
                            UserNavId = 7,
                            Zipcode = ""
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7680),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7750),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7755),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7760),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7765),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7769),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7774),
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
                            CreationDate = new DateTime(2022, 6, 20, 15, 2, 4, 339, DateTimeKind.Local).AddTicks(7780),
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
                    b.Property<int>("ExpensesCategoryNavId")
                        .HasColumnType("int");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.HasKey("ExpensesCategoryNavId", "UserNavId");

                    b.HasIndex("UserNavId");

                    b.ToTable("ExpenseCategoryUser");

                    b.HasData(
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 7
                        });
                });

            modelBuilder.Entity("Economiq.Shared.Models.Email", b =>
                {
                    b.HasOne("Economiq.Shared.Models.User", "UserNav")
                        .WithMany("Emails")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Expense", b =>
                {
                    b.HasOne("Economiq.Shared.Models.ExpenseCategory", "CategoryNav")
                        .WithMany("ExpensesNav")
                        .HasForeignKey("CategoryNavId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economiq.Shared.Models.Recipient", "RecipientNav")
                        .WithMany("ExpenseNav")
                        .HasForeignKey("RecipientNavId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Economiq.Shared.Models.User", "UserNav")
                        .WithMany("UserExpensesNav")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryNav");

                    b.Navigation("RecipientNav");

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.HasOne("Economiq.Shared.Models.User", "UserNav")
                        .WithMany("RecipientNav")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("ExpenseCategoryUser", b =>
                {
                    b.HasOne("Economiq.Shared.Models.ExpenseCategory", null)
                        .WithMany()
                        .HasForeignKey("ExpensesCategoryNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Economiq.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Economiq.Shared.Models.ExpenseCategory", b =>
                {
                    b.Navigation("ExpensesNav");
                });

            modelBuilder.Entity("Economiq.Shared.Models.Recipient", b =>
                {
                    b.Navigation("ExpenseNav");
                });

            modelBuilder.Entity("Economiq.Shared.Models.User", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("RecipientNav");

                    b.Navigation("UserExpensesNav");
                });
#pragma warning restore 612, 618
        }
    }
}
