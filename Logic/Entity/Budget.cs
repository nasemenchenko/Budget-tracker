using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    public class Budget
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Description Description { get; set; }
        public bool TransactionType { get; set; } //+ или -

    }
    
}
