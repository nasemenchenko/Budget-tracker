using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    class Income
    {
        public int ID { get; set; }
        public decimal Dividance { get; set; }
        public decimal Salary { get; set; }
        public decimal Gift { get; set; }
        public decimal Part { get; set; }
        public virtual User Users { get; set; }
    }
}
