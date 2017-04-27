using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Annotations;

namespace MVVMDemo.Model
{
    public class StudentModel
    {
    }

    public class Student : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
                RaisePropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
                RaisePropertyChanged(nameof(FullName));
            }
        }
        public string FullName => _firstName +" "+_lastName;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 }
