using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestWPF
{
    /// <summary>
    ///  Добавление в проект новый класс Employee, который будет представлять модель приложения.
    ///  Для уведомления системы об изменениях свойств модель Employee реализует интерфейс INotifyPropertyChanged.
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private string position;
        private DateTime birthDate;

        /// <summary>
        /// Свойство Name, используется для ввода и отображения имени сотрудника.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Свойство Position, используется для ввода и отображения должности сотрудника.
        /// </summary>
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        /// <summary>
        /// Свойство BirthDate, используется для ввода и отображения возраста сотрудника.
        /// </summary>
        public DateTime BirthDate
        {
        get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
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