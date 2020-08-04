using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Windows.Input;

namespace A3Farming.ViewModels
{
    /// <summary>
    /// relay command
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// event to raise if can execute changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// execute action
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        /// can execute predicate
        /// </summary>
        private readonly Predicate<object> canExecute;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="execute">execute action</param>
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="execute">execute action</param>
        /// <param name="canExecute">predicate to indicate if the command can be executed</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        /// <summary>
        /// returns wether the command can be executed
        /// </summary>
        /// <param name="parameter">parameters</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null || CanExecute(parameter);
        }

        /// <summary>
        /// executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
