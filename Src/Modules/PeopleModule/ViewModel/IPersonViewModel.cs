using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrimsDemoApplication.Infrastructure;
using PrismDemoApplication.Business;

namespace PeopleModule.ViewModel
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);

        Person SelectedPerson { get; set; }
    }
}
