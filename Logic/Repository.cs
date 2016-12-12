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

        public event Action onUserListChanged;
        public List<User> Users { get; set; }
        public List<Description> Description { get; set; }
        public List<Budget> Budget { get; set; }
        Context context;
        public Repository(Context c)
        {
            // using (var c = new Context())
            //   {
            context = c;
            Users = c.User.ToList();
            Description = c.Description.ToList();
            Budget = c.Budget.ToList();
            // }
        }
        public void AddUser(User user)
        {
            if (user == null) throw new Exception("ghjjdslds");
            Users.Add(user);
            DbUpdater.AddUser(user);
            //  context.User.Add(user);
            // context.SaveChanges();

        }
        public void AddUser(string name, string location)
        {
            AddUser(new User(name, location));
            onUserListChanged?.Invoke();
        }
        public void ClearUsersList()
        {
            DbUpdater.ClearUsers();
            Users.Clear();
            onUserListChanged?.Invoke();
        }
    }
}
