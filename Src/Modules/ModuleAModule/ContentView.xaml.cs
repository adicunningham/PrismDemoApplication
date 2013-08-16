using System.Windows.Controls;
using PrimsDemoApplication.Infrastructure;

namespace ModuleA
{
    /// <summary>
    /// Interaction logic for ContentView.xaml
    /// </summary>
    public partial class ContentView : UserControl, IContentView
    {
        public ContentView()
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
