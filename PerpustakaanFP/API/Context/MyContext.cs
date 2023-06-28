using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountRoles> AccountRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many Book has one Borrow
            modelBuilder.Entity<Book>()
                        .HasMany(bk => bk.Borrow)
                        .WithOne(b => b.Book)
                        .IsRequired(false)
                        .HasForeignKey(b => b.B_BookId);

            // Many Member has one Borrow
            modelBuilder.Entity<Member>()
                        .HasMany(m => m.Borrow)
                        .WithOne(b => b.Member)
                        .IsRequired(false)
                        .HasForeignKey(b => b.B_MemberId);

            // One Account has one Employee
            modelBuilder.Entity<Member>()
                        .HasOne(m => m.Accounts)
                        .WithOne(ac => ac.Member)
                        .HasForeignKey<Accounts>(ac => ac.memberId)
                        .OnDelete(DeleteBehavior.Restrict);

            // One Account has many AccountRole
            modelBuilder.Entity<Accounts>()
                        .HasMany(r => r.AccountRoles)
                        .WithOne(ar => ar.Accounts)
                        .IsRequired(false)
                        .HasForeignKey(ar => ar.AccountId);

            // One Role has many AccountRole
            modelBuilder.Entity<Roles>()
                        .HasMany(r => r.AccountRoles)
                        .WithOne(ar => ar.Roles)
                        .IsRequired(false)
                        .HasForeignKey(ar => ar.Roleid);

        }
    }
}