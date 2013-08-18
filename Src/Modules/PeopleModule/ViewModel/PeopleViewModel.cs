using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleModule.Views;
using PrimsDemoApplication.Infrastructure;
using PrismDemoApplication.Business;

namespace PeopleModule.ViewModel
{
    public class PeopleViewModel : ViewModelBase, IPeopleViewModel
    {
        private ObservableCollection<Person> _people; 

        public PeopleViewModel(IPeopleView view) : base(view)
        {
            CreatePeople();
        }

        public string ViewName
        {
            get
            {
                return "People View";
            }
        }

        public ObservableCollection<Person> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                OnPropertyChanged("People");
            }
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();

            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = String.Format("First {0}", i),
                    LastName = String.Format("Last {0}", i)
                });
            }

            People = people;
        }
    }
}
