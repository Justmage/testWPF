using System;
using System.Windows.Input;

namespace TestWPF
{
    /// <summary>
    ///  Класс, который реализует интерфейс ICommand, для создания комманд сохранения/удаления/добавления сотрудников.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        /// <summary>
        /// Конструктор, принимающий 2 параметра, которые являются делегатами Action<> и Function<>
        /// </summary>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Реализация события CanExecuteChanged вызывается при изменении условий, указывающее, может ли команда выполняться. Для этого используется событие CommandManager.RequerySuggested.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Реализация комманды CanExecute определяет, может ли команда выполняться
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Реализация комманды Execute, которая выполняет логику комманды
        /// </summary>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}