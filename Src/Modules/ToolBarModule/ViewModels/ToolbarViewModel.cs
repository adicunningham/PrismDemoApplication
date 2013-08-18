using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimsDemoApplication.Infrastructure;
using ToolBarModule.Views;

namespace ToolBarModule.ViewModels
{
    public class ToolbarViewModel : ViewModelBase, IToolbarViewModel
    {
        public ToolbarViewModel(IToolbarView view) : base(view)
        {
        }
    }
}
