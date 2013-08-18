using System.Windows.Controls;
using PrimsDemoApplication.Infrastructure;

namespace StatusBarModule.Views
{
    /// <summary>
    /// Interaction logic for StatusBarView.xaml
    /// </summary>
    public partial class StatusBarView : UserControl, IStatusBarView
    {
        public StatusBarView()
        {
            InitializeComponent();
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
