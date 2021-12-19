using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public interface IKennel
    {
        
        List<IPerson> Customers { get; set; }
        List<IDog> Dogs { get; set; }
        List<IDogServices> DogServices { get; set; }
        List<IDog> DogsInKennel { get; set; }
        void NewDog(string v, IPerson customer);
        void CheckRegisteredCustomers();
        void CheckRegisteredDogs();
        void DogAndOwner();
        void CheckInDog(IDog dogIn);
        void CheckOutDog(IDog dogOut);
        void NewCustomer(string firstName, string lastName);
    }
}
