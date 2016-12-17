using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    public class Budget
    {
        public int ID { get; set; }
        
        [NotMapped]
        public User User { get; set; }
        public Description Description { get; set; }
        public bool TransactionType { get; set; } //+ или -

    }
    
}
