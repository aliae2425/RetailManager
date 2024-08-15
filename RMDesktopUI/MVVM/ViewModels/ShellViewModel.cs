using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.MVVM.ViewModels
{
    internal class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginMV; 
        public ShellViewModel(LoginViewModel loginMV)
        {
            _loginMV = loginMV;
            ActivateItemAsync(_loginMV);
        }
    }
}
