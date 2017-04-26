using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ButtonCommand:ICommand
    {
        private Action WhatToExecute;
        private Func<bool> WhenToExecute;

        public ButtonCommand(Action what, Func<bool> when)
        {
            WhatToExecute = what;
            WhenToExecute = when;
        }
        public bool CanExecute(object parameter)
        {
            return WhenToExecute();
        }

        public void Execute(object parameter)
        {
            WhatToExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}
