using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public static class Factory
    {

        public static IDog CreateDog(string name, IPerson owner)
        {            
            return new Dog(name, owner);
        }

        public static IPerson CreateCustomer(string firstName, string lastName)
        {
            return new Customer(firstName, lastName);
        }

        public static IKennel CreateKennel()
        {
            return new Kennel();
        }
        public static IMenu CreateMenu()
        {
            return new Menu();
        }
    }
}
