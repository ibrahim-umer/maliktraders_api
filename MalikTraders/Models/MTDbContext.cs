using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class MTDbContext : DbContext
    {
        public MTDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FSON37C\SQLEXPRESS;Initial Catalog=MTDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.email).IsUnique();
                entity.HasIndex(e => e.UserName).IsUnique();
            });
            builder.Entity<UserDetails>(entity => {
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
                entity.HasIndex(e => e.CNIC).IsUnique();
            });
        }
        public MTDbContext(DbContextOptions<MTDbContext> optn): base(optn) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccDetails> AccDetails { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<MTServices> MTServices { get; set; }

    }
}
