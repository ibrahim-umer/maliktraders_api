using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalikTraders.Models
{
    public class MTDbContext : DbContext
    {
        public MTDbContext(DbContextOptions<MTDbContext> optn): base(optn) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccDetails> AccDetails { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<MTServices> MTServices { get; set; }

    }
}
