using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   static class DbUpdater
    {
        public static void AddUser(User u)
        {
            using (Context context = new Context())
            {
                context.User.Add(u);
                context.SaveChanges();
            }

        }
        public static void AddTransaction(Budget budget)
        {
            using (var c = new Context())
            {
                c.Budget.Add(budget);
                c.SaveChanges();
            }   
        }

        public static void ClearUsers()
        {

            using (Context c = new Context())
            {

                c.User.RemoveRange(c.User);
                c.Description.RemoveRange(c.Description);
                c.Budget.RemoveRange(c.Budget);
                c.SaveChanges();
            }

        }
    }
}
