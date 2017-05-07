using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnScreenConductor.ViewModels
{
    public class AppViewModel : Conductor<object>
    {
        public void ShowRedScreen()
        {
            ActivateItem(new RedViewModel());
        }

        public void ShowGreenScreen()
        {
            ActivateItem(new GreenViewModel());
        }

        public void ShowBlueScreen()
        {
            ActivateItem(new BlueViewModel());
        }

    }
}
