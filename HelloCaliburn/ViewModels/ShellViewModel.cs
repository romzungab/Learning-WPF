using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.PresentationFramework;

namespace HelloCaliburn.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private string _Name;
        private bool _CanSayHello;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyOfPropertyChange(()=>Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello => !string.IsNullOrEmpty(Name);

        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}");
        }
    }
    
}
