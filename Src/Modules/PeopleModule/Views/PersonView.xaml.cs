﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using PeopleModule.ViewModel;
using PeopleModule.Views;
using PrimsDemoApplication.Infrastructure;
using PrismDemoApplication.Business;

namespace PeopleModule
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl, IPersonView
    {
        public PersonView()
        {
            InitializeComponent();


            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
            {
                var context = (ObservableObject<object>) s;
                var selectedPerson = (Person) context.Value;
                (ViewModel as IPersonViewModel).SelectedPerson = selectedPerson;
            };
        }

        public PrimsDemoApplication.Infrastructure.IViewModel ViewModel
        {
            get
            {
                return (IViewModel) DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
