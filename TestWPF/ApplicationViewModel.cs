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

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>
                    {
                        Employee emp = obj as Employee;
                        if (emp != null)
                        {
                            emp = SelectedEmployee;
                            Employes.Remove(SelectedEmployee);
                            Employes.Insert(Employes.Count, emp);
                            SelectedEmployee = emp;
                        }
                    },
                    (obj) => Employes.Count > 0));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Employee employee = obj as Employee;
                        if (employee != null)
                        {
                            Employes.Remove(employee);
                        }
                    },
                    (obj) => Employes.Count > 0));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
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
                  }));
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