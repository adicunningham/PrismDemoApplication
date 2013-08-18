using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemoApplication.Business
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Properties

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private int _age;

        public int Age
        {
            get
            {
                return _age;

            }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        private DateTime? _lastUpdated;

        public DateTime? LastUpdated
        {
            get
            {
                return _lastUpdated;
            }
            set

            {
                _lastUpdated = value;
                OnPropertyChanged("LastUpdated");
            }
        }

        #endregion

        #region INotifiyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }



        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch(columnName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(_firstName))
                        {
                            error = "First Name required";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(_lastName))
                        {
                            error = "Last Name is required";
                        }
                        break;
                    case "Age":
                        if ((_age < 18) || (_age > 85))
                        {
                            error = "Age is out of range, must be between 18 and 85";
                        }
                        break;
                }
                Error = error;
                return error;
            }
        }

        #endregion
    }
}
