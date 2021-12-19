using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            IKennel kennel = Factory.CreateKennel();
            IMenu menu = Factory.CreateMenu();

            bool running = true;

            kennel.NewCustomer("Lena", "Lingonstig");
            kennel.NewCustomer("Magnus", "Sterling");
            kennel.NewDog("Elvira", kennel.Customers[1]);
            kennel.NewDog("Bosse", kennel.Customers[0]);
            kennel.NewDog("Styrbjörn", kennel.Customers[1]);

            while (running)
            {
                running = menu.Show(kennel);
            }
        }
    }
}
