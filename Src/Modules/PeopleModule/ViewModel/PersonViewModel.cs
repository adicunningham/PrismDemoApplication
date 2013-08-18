using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using PeopleModule.Views;
using PrimsDemoApplication.Infrastructure;
using PrismDemoApplication.Business;

namespace PeopleModule.ViewModel
{
    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {
        private IEventAggregator _eventAggregator;

        public string ViewName
        {
            get
            {
                return string.Format("{0}, {1}", Person.FirstName, Person.LastName);
            }
        }

        public DelegateCommand SaveCommand { get; set; }

        public PersonViewModel(IPersonView view, IEventAggregator eventAggregator)
            : base(view)
        {

            SaveCommand = new DelegateCommand(Save, CanSave);

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);

            _eventAggregator = eventAggregator;
        }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }

        private void Save()
        {
            Person.LastUpdated = DateTime.Now;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}", Person.FirstName, Person.LastName));
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
