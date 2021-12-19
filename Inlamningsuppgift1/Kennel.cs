using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public class Kennel : IKennel
    {
        public List<IPerson> Customers { get; set; } = new List<IPerson>();
        public List<IDog> Dogs { get; set; } = new List<IDog>();
        public List<IDogServices> DogServices { get; set; } = new List<IDogServices>();
        public List<IDog> DogsInKennel { get; set; } = new List<IDog>();
        public void NewCustomer(string firstName, string lastName)
        {
            Customers.Add(Factory.CreateCustomer(firstName, lastName));
        }

        public void NewDog(string name, IPerson owner)
        {
            if (owner != null)
            {
                Dogs.Add(Factory.CreateDog(name, owner));
            }
            else
            {
                Console.WriteLine("Please enter yourself as owner");
            }

        }
        public void CheckRegisteredCustomers()
        {
            foreach (var c in Customers)
            {
                Console.WriteLine(c.FirstName + " " + c.LastName);
            }
        }

        public void CheckRegisteredDogs()
        {
            foreach (var d in Dogs)
            {
                Console.WriteLine(d.Name);
            }
        }

        public void DogAndOwner()
        {
            foreach (var d in Dogs)
            {
                Console.WriteLine(d.Name + "'s owner is " + d.Owner.FirstName + " " + d.Owner.LastName);
            }
        }

        public void CheckInDog(IDog dogIn)
        {
            DogsInKennel.Add(dogIn);
        }
        public void CheckOutDog(IDog dogOut)
        {
            DogsInKennel.Remove(dogOut);
        }
    }
}
