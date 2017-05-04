using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using CaliburnEvent.Services;

namespace CaliburnEvent.ViewModels
{
    [Export(typeof(ColorViewModel))]
    public class ColorViewModel
    {
        private readonly IEventAggregator _events;
       
        [ImportingConstructor]
        public ColorViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public void Red()
        {
            _events.PublishOnUIThread(new ColorEvent(new SolidColorBrush(Colors.Red)));
        }

        public void Green()
        {
            _events.PublishOnUIThread(new ColorEvent(new SolidColorBrush(Colors.Green)));
        }
        public void Blue()
        {
            _events.PublishOnUIThread(new ColorEvent(new SolidColorBrush(Colors.Blue)));
        }

    }
    

}
