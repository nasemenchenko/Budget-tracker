using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Context : DbContext
    {
        DbSet<Budget> Budget;
        DbSet<Description> Description;
        DbSet<User> User;
        public Context() : base("localsql")
        {

        }

    }
}
