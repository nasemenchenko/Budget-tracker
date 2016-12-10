using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class Repository
    {
        public List<User> User { get; set; }
        public List<Description> Description { get; set; }
        public List<Budget> Budget { get; set; }
        public Repository()
        {
            using (var c = new Context())
            {
                User = c.User.ToList();
                Description = c.Description.ToList();
                Budget = c.Budget.ToList();
            }
        }
        private void AddUser(User user)
        {
            User.Add(user);
            using (var c = new Context())
            {
                c.User.Add(user);
                c.SaveChanges();
            }
        }
        public void AddUser(string name, string location)
        {
            AddUser(new User { Name = name, Location = location });
        }
        public void ClearUsersList()
        {
            using (var c = new Context())
            {
                c.User.RemoveRange(c.User);
                c.SaveChanges();
            }
        }
    }
}
