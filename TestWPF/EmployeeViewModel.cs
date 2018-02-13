using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestWPF
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee employee;

        public EmployeeViewModel(Employee emp)
        {
            employee = emp;
        }

        public string Name
        {
            get { return employee.Name; }
            set
            {
                employee.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Position
        {
            get { return employee.Position; }
            set
            {
                employee.Position = value;
                OnPropertyChanged("Position");
            }
        }
        public DateTime BirthDate
        {
            get { return employee.BirthDate; }
            set
            {
                employee.BirthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}