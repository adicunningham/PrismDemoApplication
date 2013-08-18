using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.Practices.Prism.Events;
using PrimsDemoApplication.Infrastructure;
using StatusBarModule.Views;

namespace StatusBarModule.ViewModels
{
    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        private IEventAggregator _eventAggregator;
        
        public StatusBarViewModel(IStatusBarView view, IEventAggregator eventAggregator) : base(view)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Subscribe(PersonUpdated);
        }

        public string _message = "Ready";
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        private void PersonUpdated(string obj)
        {
            Message = String.Format("{0} was updated", obj);
        }
    }
}
