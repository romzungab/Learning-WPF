using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public StudentViewModel()
        {
         LoadStudents();   
        }
        private void LoadStudents()
        {
            var students = new ObservableCollection<Student> {
                        new Student { FirstName = "Mark", LastName = "Allain" },
                        new Student { FirstName = "Allen", LastName = "Brown" },
                        new Student { FirstName = "Linda", LastName = "Hamerski" } };
            Students = students;
        }
    }
}
