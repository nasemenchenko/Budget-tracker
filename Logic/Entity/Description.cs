using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    public class Description
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string TransactionName { get; set; }
        public string TransactionComment { get; set; }
        public decimal TransactionSum { get; set; }
    }
}
