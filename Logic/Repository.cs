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
        private void AddUser(User user)
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
        private void AddTransaction(Budget budget)
        {
            if (budget == null) throw new Exception("");
            Budget.Add(budget);
            DbUpdater.AddTransaction(budget);
        }
        public void AddTransaction(string name, string transactionName, bool transactionType, decimal sum, string transactionComment)
        {
            User user = SearchUserByName(name);
            AddTransaction(new Budget()
            {
                User = user,
                Description = new Description()
                {
                    TransactionName = transactionName,
                    TransactionComment = transactionComment,
                    TransactionSum=sum,
                    Date = DateTime.Now
                },
                TransactionType = transactionType
            }
                );

            
            }

        public User SearchUserByName(string name)
        {
            return Users.Find(u => u.Name == name);

        }
        public void ClearUsersList()
        {
            DbUpdater.ClearUsers();
            Users.Clear();
            onUserListChanged?.Invoke();
        }
    }
}
