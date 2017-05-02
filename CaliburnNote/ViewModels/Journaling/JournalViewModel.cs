using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.PresentationFramework;

namespace CaliburnNote.ViewModels.Journaling
{
    public class JournalViewModel:PropertyChangedBase
    {
        private bool _CanDisplayNote = false;
        private string _Note=string.Empty;
        private string _NoteDisplay=string.Empty;

        public bool CanDislayNote
        {
            get { return _CanDisplayNote; }
            set
            {
                _CanDisplayNote = value;
                NotifyOfPropertyChange(()=>CanDislayNote);
            }
        }

        public string Note
        {
            get { return _Note; }
            set
            {
                _Note = value;
                NotifyOfPropertyChange(()=>Note);
            }
        }

        public string NoteDisplay
        {
            get { return _NoteDisplay; }
            set
            {
                _NoteDisplay = value;
                NotifyOfPropertyChange(()=>NoteDisplay);
            }
        }

        public void DisplayNote()
        {
            NoteDisplay = Note;
        }
    }
}
