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
        public MyICommand DeleteCommand { get; set; }
        public StudentViewModel()
        {
         LoadStudents();  
         DeleteCommand = new MyICommand(OnDelete, CanDelete);    
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }

        private Student _selectedStudent { get; set; }

        public Student SelectedStudent {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private void LoadStudents()
        {
            var students = new ObservableCollection<Student> {
                        new Student { FirstName = "Mark", LastName = "Allain" },
                        new Student { FirstName = "Allen", LastName = "Brown" },
                        new Student { FirstName = "Linda", LastName = "Hamerski" } };
            Students = students;
        }

        public int GetStudentCount()
        {
            return Students.Count;
        }

    }
}
