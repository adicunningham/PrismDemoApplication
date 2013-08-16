using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ContentViewViewModel : IContentViewViewModel
    {
        public PrimsDemoApplication.Infrastructure.IView View {get; set; }

        public ContentViewViewModel(IContentView view)
        {
            View = view;
            View.ViewModel = this;
        }
    
    }
}
