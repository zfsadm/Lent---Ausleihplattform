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
    }
}
