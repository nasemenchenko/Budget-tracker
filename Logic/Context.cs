using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Context : DbContext
    {
        public DbSet<Budget> Budget { get; set; }
        public DbSet<Description> Description { get; set; }
        public DbSet<User> User { get; set; }
        public Context() : base("localsql")
        {

        }

    }
}
