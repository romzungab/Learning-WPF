using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.PresentationFramework;

namespace CaliburnEx
{
    public class ShellViewModel:PropertyChangedBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                NotifyOfPropertyChange(()=> Message);
                NotifyOfPropertyChange(()=> CanChangeMessage);
            }
        }

        private int _pressCount;

        public ShellViewModel()
        {
            Message = "Hello World";
        }

        public void ChangeMessage()
        {
            _pressCount++;
            Message = "Presses = " + _pressCount;
        }

        public bool CanChangeMessage
        {
            get { return _pressCount > 10; }
        }
    }
}
