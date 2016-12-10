using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public User()
        {

        }
        public User(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
