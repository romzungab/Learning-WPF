using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnMicroApp.ViewModels
{
    public class AppViewModel:PropertyChangedBase
    {
        private int _count = 50;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyOfPropertyChange(()=>Count);
            }
        }

        public void IncrementCount()
        {
            Count++;
            NotifyOfPropertyChange(()=>CanIncrementCount);
        }

        public void IncrementCount(int delta)
        {
            Count += delta;
            NotifyOfPropertyChange(() => CanIncrementCount);
        }


        public bool CanIncrementCount => Count < 100;
    }
}
