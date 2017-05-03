using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.PresentationFramework;
using CaliburnNote.ViewModels.Journaling;
using CaliburnNote.Views.Journaling;

namespace CaliburnNote.ViewModels
{
    public class MainViewModel: PropertyChangedBase
    {
        private const string WindowTitleDefault = "So. Just Note It";
        private string _windowTitle = WindowTitleDefault;
        private JournalViewModel _journalView;

        public MainViewModel()
        {
            JournalView = new JournalViewModel();
        }

        public JournalViewModel JournalView
        {
            get { return _journalView; }
            set
            {
                _journalView = value;
               NotifyOfPropertyChange(()=>JournalView);  
            } 
        }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(()=>WindowTitle);
            }
        }

    }
}
