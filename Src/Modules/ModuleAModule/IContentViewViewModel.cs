﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrimsDemoApplication.Infrastructure;

namespace ModuleA
{
    interface IContentViewViewModel : IViewModel
    {
        string Message { get; set; }
    }
}
