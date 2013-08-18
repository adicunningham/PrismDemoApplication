using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrimsDemoApplication.Infrastructure;

namespace PeopleModule.ViewModel
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);
    }
}
