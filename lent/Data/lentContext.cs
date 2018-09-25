using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lent.Models;

namespace lent.Models
{
    public class lentContext : DbContext
    {
        public lentContext (DbContextOptions<lentContext> options)
            : base(options)
        {
        }

        public DbSet<lent.Models.Item> Item { get; set; }

        public DbSet<lent.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(u => u.Owner)
                .WithMany(i => i.ownedItems).OnDelete(DeleteBehavior.Restrict);

            /* modelBuilder.Entity<User>()
                .HasMany(i => i.ownedItems)
                .WithOne(u => u.Owner).OnDelete(DeleteBehavior.Restrict); */

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Borrower)
                .WithMany(b => b.borrowedItems).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
