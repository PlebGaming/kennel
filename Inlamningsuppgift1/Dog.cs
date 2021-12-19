using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public class Dog : IDog
    {
        public List<IDogServices> ServicesOrdered { get; set; } = new List<IDogServices>();
        public Dog(string name, IPerson owner)
        {
            Name = name;
            Owner = owner;
        }
        public string Name { get; set ; }

        public IPerson Owner { get; set; }

    }
}
