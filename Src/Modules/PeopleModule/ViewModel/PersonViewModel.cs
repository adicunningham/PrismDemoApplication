using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using PeopleModule.Views;
using PrimsDemoApplication.Infrastructure;
using PrismDemoApplication.Business;

namespace PeopleModule.ViewModel
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        public string ViewName
        {
            get
            {
                return string.Format("{0}, {1}", Person.FirstName, Person.LastName);
            }
        }

        public DelegateCommand<Person> SaveCommand { get; set; }

        public PersonViewModel(IPersonView view)
            : base(view)
        {

            SaveCommand = new DelegateCommand<Person>(Save, CanSave);
        }

        private bool CanSave(Person value)
        {
            return Person.Error == null;
        }

        private void Save(Person value)
        {
            Person.LastUpdated = DateTime.Now.AddYears(Convert.ToInt32((value.Age)));
        }

        private Person _person;

        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                _person.PropertyChanged += PersonOnPropertyChanged;
                OnPropertyChanged("Person");
            }
        }

        private void PersonOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0
            };
        }


    }
}
