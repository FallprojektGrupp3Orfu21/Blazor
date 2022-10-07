using Economiq.Shared.Extensions;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Data
{
    public class EconomiqContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategory { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public EconomiqContext()
        {

        }

        public EconomiqContext(DbContextOptions<EconomiqContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Primary Keys
            modelbuilder.Entity<Expense>()
                .HasKey(e => e.Id);
            modelbuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelbuilder.Entity<ExpenseCategory>()
                .HasKey(ec => ec.Id);
            modelbuilder.Entity<Recipient>()
                .HasKey(r => r.Id);
            modelbuilder.Entity<Email>()
                .HasKey(c => new { c.UserId, c.Mail });
            modelbuilder.Entity<Budget>()
                .HasKey(b => b.Id);
            //Relations
            modelbuilder.Entity<Expense>()
                .HasOne(u => u.User)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<Budget>()
                .HasOne(u => u.User)
                .WithMany(b => b.Budgets)
                .HasForeignKey(b => b.User)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<Expense>()
                .HasOne(b => b.Budget)
                .WithMany(e => e.Expenses)
                .HasForeignKey(b => b.BudgetId)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelbuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<ExpenseCategory>()
                .HasMany(ec => ec.Users)
                .WithMany(u => u.Categories);
            modelbuilder.Entity<Recipient>()
                .HasOne(ur => ur.User)
                .WithMany(re => re.Recipients)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<Expense>()
                .HasOne(re => re.Recipient)
                .WithMany(ex => ex.ExpenseNav)
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.NoAction);



            modelbuilder.Seed();
        }

    }
}