using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
            AdditingWindow aw = new AdditingWindow();
            if (aw.ShowDialog() == true)
            {

                Employee emp = new Employee
                {
                    Name = aw.nameTextBox.Text,
                    Position = aw.positionTextBox.Text,
                    BirthDate = DateTime.Parse(aw.birthdayTextBox.Text)
                };
                Employes.Insert(Employes.Count, emp);
                SelectedEmployee = emp;
                MessageBox.Show("Новый сотрудник добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Добавление отменено");
            }
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

        public ApplicationViewModel()
        {
            Employes = new ObservableCollection<Employee>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}