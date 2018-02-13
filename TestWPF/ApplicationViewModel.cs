using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestWPF
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Employee selectedEmployee;

        public ObservableCollection<Employee> Employes { get; set; }
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public ApplicationViewModel()
        {
            Employes = new ObservableCollection<Employee>
            {
                new Employee {Name="aaa", Position="123", BirthDate=new DateTime(2000,1,12) },
                new Employee {Name="bbb", Position="456", BirthDate =new DateTime(2001,1,12) },
                new Employee {Name="ccc", Position="789", BirthDate=new DateTime(2002,1,12) },
                new Employee {Name="ddd", Position="012", BirthDate=new DateTime(2003,1,12) }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}