using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private Customer _obj = new Customer();
        private ButtonCommand _cmd;

        public CustomerViewModel()
        {
            _cmd = new ButtonCommand(_obj.CalculateTax, _obj.IsValid);
        }

        public ICommand ButtonClick
        {
            get { return _cmd; }
        }

        public string TxtCustomerName
        {
            get { return _obj.CustomerName; }
            set { _obj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return Convert.ToString(_obj.Amount); }
            set
            {
                _obj.Amount = Convert.ToDouble(value);
                OnPropertyChanged(LblAmountColor);
                Calculate();
               }
        }

        public string LblTax
        {
            get { return _obj.Tax.ToString(); }
            set { _obj.CalculateTax();}
        }

        public string LblAmountColor
        {
            get
            {
                if (_obj.Amount > 2000)
                {
                    return "Blue";
                }
                return _obj.Amount > 1500 ? "Red" : "Yellow";
            }
        }

        public bool IsMarried
        {
            get { return _obj.Married == "Married"; }
            set { _obj.Married = value ? "Married" : "Unmarried"; }
        }

        public void Calculate()
        {
            _obj.CalculateTax();
            OnPropertyChanged("LblTax");
            
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
