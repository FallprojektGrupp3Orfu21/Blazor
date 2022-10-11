using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Shared.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var u1 = new User() { Id = 1, UserName = "JuliaH", Fname = "Julia", Lname = "Hook", Password = "Testing123", Gender = "Female", City = "Orebro", CreationDate = DateTime.Now };
            var u2 = new User() { Id = 2, UserName = "AlexV", Fname = "Alexander", Lname = "Volonen", Password = "Testing234", Gender = "Male", City = "Orebro", CreationDate = DateTime.Now };
            var u3 = new User() { Id = 3, UserName = "Peppo", Fname = "Stefan", Lname = "Krakowsky", Password = "Testing345", Gender = "Male", City = "Orebro", CreationDate = DateTime.Now };
            var u4 = new User() { Id = 4, UserName = "WinnieH", Fname = "Winnie", Lname = "Huynh", Password = "Testing456", Gender = "Female", City = "Orebro", CreationDate = DateTime.Now };
            var u5 = new User() { Id = 5, UserName = "Ericx", Fname = "Eric", Lname = "Flodin", Password = "Testing567", Gender = "Male", City = "Orebro", CreationDate = DateTime.Now };
            var u6 = new User() { Id = 6, UserName = "AndersB", Fname = "Anders", Lname = "Bergstrom", Password = "Testing678", Gender = "Male", City = "Fjugesta", CreationDate = DateTime.Now };
            var u7 = new User() { Id = 7, UserName = "PeterH", Fname = "Peter", Lname = "Hafid", Password = "Testing789", Gender = "Male", City = "Orebro", CreationDate = DateTime.Now };
            var u8 = new User() { Id = 8, UserName = "admin", Fname = "admin", Lname = "admin", Password = "admin", Gender = "Male", City = "Orebro", CreationDate = DateTime.Now };
            modelBuilder.Entity<User>().HasData(u1, u2, u3, u4, u5, u6, u7, u8);

            var em1 = new Email() { Mail = "JuliaH@test.com", UserId = 1 };
            var em2 = new Email() { Mail = "AlexV@test.com", UserId = 2 };
            var em3 = new Email() { Mail = "Peppo@test.com", UserId = 3 };
            var em4 = new Email() { Mail = "WinnieH@test.com", UserId = 4 };
            var em5 = new Email() { Mail = "Ericx@test.com", UserId = 5 };
            var em6 = new Email() { Mail = "AndersB@test.com", UserId = 6 };
            var em7 = new Email() { Mail = "PeterH@test.com", UserId = 7 };
            var em8 = new Email() { Mail = "admin@admin.com", UserId = 8 };
            modelBuilder.Entity<Email>().HasData(em1, em2, em3, em4, em5, em6, em7, em8);

            var ec = new ExpenseCategory() { Id = 1, CategoryName = "Rent", CreationDate = DateTime.Now };
            var ec2 = new ExpenseCategory() { Id = 2, CategoryName = "Food", CreationDate = DateTime.Now };
            var ec3 = new ExpenseCategory() { Id = 3, CategoryName = "Transport", CreationDate = DateTime.Now };
            var ec4 = new ExpenseCategory() { Id = 4, CategoryName = "Clothing", CreationDate = DateTime.Now };
            var ec5 = new ExpenseCategory() { Id = 5, CategoryName = "Entertainment", CreationDate = DateTime.Now };
            modelBuilder.Entity<ExpenseCategory>().HasData(ec, ec2, ec3, ec4, ec5);

            var r1 = new Recipient() { Id = 1, Name = "ICA", UserId = 1};
            var r2 = new Recipient() { Id = 2, Name = "H&M", UserId = 5 };
            var r3 = new Recipient() { Id = 3, Name = "Alfred", UserId = 3 };
            var r4 = new Recipient() { Id = 4, Name = "Hanna", UserId = 4 };
            var r5 = new Recipient() { Id = 5, Name = "ICA", UserId = 7 };
            var r6 = new Recipient() { Id = 6, Name = "Coop", UserId = 7 };
            modelBuilder.Entity<Recipient>().HasData(r1, r2, r3, r4, r5, r6);


            var e1 = new Expense() { Id = 1, Amount = 25, Comment = "Glass", CategoryId = 2, CreationDate = DateTime.Now, ExpenseDate = DateTime.Now.Date, UserId = 1 };
            modelBuilder.Entity<Expense>().HasData(e1);

            modelBuilder.Entity<ExpenseCategory>()
            .HasMany(d => d.Users)
            .WithMany(p => p.Categories)
            .UsingEntity(x => x.HasData(
                new { CategoriesId = 1, UsersId = 1 },
                new { CategoriesId = 1, UsersId = 2 },
                new { CategoriesId = 1, UsersId = 3 },
                new { CategoriesId = 1, UsersId = 4 },
                new { CategoriesId = 1, UsersId = 5 },
                new { CategoriesId = 1, UsersId = 6 },
                new { CategoriesId = 1, UsersId = 7 },
                new { CategoriesId = 2, UsersId = 1 },
                new { CategoriesId = 2, UsersId = 2 },
                new { CategoriesId = 2, UsersId = 3 },
                new { CategoriesId = 2, UsersId = 4 },
                new { CategoriesId = 2, UsersId = 5 },
                new { CategoriesId = 2, UsersId = 6 },
                new { CategoriesId = 2, UsersId = 7 },
                new { CategoriesId = 3, UsersId = 1 },
                new { CategoriesId = 3, UsersId = 2 },
                new { CategoriesId = 3, UsersId = 3 },
                new { CategoriesId = 3, UsersId = 4 },
                new { CategoriesId = 3, UsersId = 5 },
                new { CategoriesId = 3, UsersId = 6 },
                new { CategoriesId = 3, UsersId = 7 },
                new { CategoriesId = 4, UsersId = 1 },
                new { CategoriesId = 4, UsersId = 2 },
                new { CategoriesId = 4, UsersId = 3 },
                new { CategoriesId = 4, UsersId = 4 },
                new { CategoriesId = 4, UsersId = 5 },
                new { CategoriesId = 4, UsersId = 6 },
                new { CategoriesId = 4, UsersId = 7 },
                new { CategoriesId = 5, UsersId = 1 },
                new { CategoriesId = 5, UsersId = 2 },
                new { CategoriesId = 5, UsersId = 3 },
                new { CategoriesId = 5, UsersId = 4 },
                new { CategoriesId = 5, UsersId = 5 },
                new { CategoriesId = 5, UsersId = 6 },
                new { CategoriesId = 5, UsersId = 7 }
            ));
        }
    }
}