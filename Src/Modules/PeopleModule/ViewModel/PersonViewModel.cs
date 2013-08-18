using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private IPersonRepository _personRepository;
        


        #region Constructors

        public PersonViewModel(IPersonView view, IEventAggregator eventAggregator, IPersonRepository personRepository)
            : base(view)
        {
            _personRepository = personRepository;
            SaveCommand = new DelegateCommand(Save, CanSave);
            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region Commands
        
        public DelegateCommand SaveCommand { get; set; }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }

        private void Save()
        {
            //Person.LastUpdated = DateTime.Now;

            int count = _personRepository.SavePerson(Person);
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0}, {1}", Person.FirstName, Person.LastName));
            MessageBox.Show(count.ToString());
        }

        #endregion

        #region Properties

        public string ViewName
        {
            get
            {
                return string.Format("{0}, {1}", Person.FirstName, Person.LastName);
            }
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

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        #endregion

        #region Event Handlers

        private void PersonOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Methods

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0
            };
        }

        #endregion




    }
}
