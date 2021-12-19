using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift1
{
    public interface IDog
    {
        List<IDogServices> ServicesOrdered { get; set; }
        string Name { get; set; }
        IPerson Owner { get; set; }
    }
}
