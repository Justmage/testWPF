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
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        public void AddEmployee()
        {
            Employee emp = new Employee();
            Employes.Insert(0, emp);
            SelectedEmployee = emp;
        }

        public void RemoveEmployee()
        {
            if (selectedEmployee != null)
            {
                Employes.Remove(SelectedEmployee);
            }
        }

        public ApplicationViewModel()
        {
            Employes = new ObservableCollection<Employee>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}