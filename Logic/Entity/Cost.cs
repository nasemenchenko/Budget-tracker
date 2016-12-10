using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entity
{
    class Cost
    {
        public int ID { get; set; }
        public decimal Products { get; set; }
        public decimal Restaurants { get; set; }
        public decimal Clothes { get; set; }
        public decimal Fitness { get; set; }
        public decimal CarService { get; set; }
        public decimal Petrol { get; set; }
        public decimal HomeItems { get; set; }
        public decimal Rest { get; set; }
        public decimal SmartPhone { get; set; }
        public decimal Internet { get; set; }
        public virtual User Users { get; set; }
    }
}
