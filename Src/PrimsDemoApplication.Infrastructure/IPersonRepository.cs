using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismDemoApplication.Business;

namespace PrimsDemoApplication.Infrastructure
{
    public interface IPersonRepository
    {
        int SavePerson(Person person);
    }
}
