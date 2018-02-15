using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TestWPF
{
    /// <summary>
    ///  Добавление в проект новый класс ApplicationViewModel , который выступает в роли "модель-представление".
    ///  Это класс модели представления, через который будут связаны модель Employee и представление MainWindow.xaml. 
    ///  Для уведомления системы об изменениях свойств модели и представления ApplicationViewModel реализует интерфейс INotifyPropertyChanged.
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///  Список объектов Employee обёрнут динамической коллекцией.
        /// </summary>
        public ObservableCollection<Employee> Employes { get; set; }
        /// <summary>
        /// Конструктор. Инициализация динамической коллекции сотрудниками(если таковые существуют).
        /// </summary>
        public ApplicationViewModel()
        {
            Employes = new ObservableCollection<Employee>();
        }

        /// <summary>
        ///  Свойство, которое указывает на выделенный элемент в DataGrid.
        /// </summary>
        private Employee selectedEmployee;
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

        /// <summary>
        ///  Комманда на редактирование сотрудника
        /// </summary>
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

        /// <summary>
        ///  Комманда на удаление сотрудника
        /// </summary>
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

        /// <summary>
        ///  Комманда на создание нового сотрудника
        /// </summary>
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

        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged. Событие PropertyChangedEventHandler возникающее при изменении свойства компонента.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}