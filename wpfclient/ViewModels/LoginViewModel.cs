using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfclient.ViewModels
{
    [Export(typeof(LoginViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class LoginViewModel : BaseViewModel
    {
    }
}
