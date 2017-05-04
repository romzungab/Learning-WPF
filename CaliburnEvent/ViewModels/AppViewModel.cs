using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using CaliburnEvent.Services;

namespace CaliburnEvent.ViewModels
{
    [Export(typeof(AppViewModel))]
    public class AppViewModel : PropertyChangedBase, IHandle<ColorEvent>
    {
        [ImportingConstructor]
        public AppViewModel(ColorViewModel colorViewModel, IEventAggregator events)
        {
            ColorViewModel = colorViewModel;
            events.Subscribe(this);
        }

        public ColorViewModel ColorViewModel { get; private set; }
        private SolidColorBrush _color;

        public SolidColorBrush Color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyOfPropertyChange(() => Color);
            }
        }

        public void Handle(ColorEvent message)
        {
            Color = message.Color;
        }
    }
}
