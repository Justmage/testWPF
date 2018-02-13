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
    public class ApplicationViewModel : INotifyPropertyChanged
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
            Employes.Insert(Employes.Count, emp);
            SelectedEmployee = emp;
        }

        public void RemoveEmployee()
        {
            if (selectedEmployee != null)
            {
                Employes.Remove(SelectedEmployee);
            }
        }

        public void EditEmployee()
        {
            if (selectedEmployee != null)
            {
                Employee emp = new Employee();
                emp = SelectedEmployee;
                Employes.Remove(SelectedEmployee);
                Employes.Insert(Employes.Count, emp);
                SelectedEmployee = emp;
            }
        }

        public void SetAge()
        {
            DateTime dateBirthDay = SelectedEmployee.BirthDate;
            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateBirthDay.Year;
            if (dateNow.Month < dateBirthDay.Month ||
                (dateNow.Month == dateBirthDay.Month && dateNow.Day < dateBirthDay.Day)) year--;
        }

        public ApplicationViewModel()
        {
            Employes = new ObservableCollection<Employee>
            {
                new Employee{Name="asdasd", Position="asdasd", BirthDate = new DateTime(2000,1,14) }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}