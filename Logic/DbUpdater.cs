using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var user = c.User.Single(x => x.Name == budget.User.Name);
                user.Budgets.Add(budget);
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

        public static void ClearUserInfo(User user)
        {
            using (Context c = new Context())
            {
                var dlist = from b in c.Budget.ToList().FindAll(d => d.User == user) select b.Description;

                //dlist.ToList().ForEach(d => c.Description.Remove(d));
                var blist = from b in c.Budget.ToList().FindAll(bud => bud.User == user) select b;
                foreach (Budget budget in blist)
                {
                    c.Entry(budget).State = EntityState.Deleted;
                }
                c.Entry(user).State = EntityState.Deleted;
                //c.Budget.RemoveRange(blist);
                c.Description.RemoveRange(dlist);
               
                c.SaveChanges();
            }
        }
    }
}