using Logic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var c = new Context())
            {
                c.Budget.ToList();
                c.User.ToArray();
                c.Budget.ToList();
                
               // c.User.ToList();
            }
           // Repository repo = new Repository();
            // будет время, сделай удаление 1 юзера
        }
    }
}
