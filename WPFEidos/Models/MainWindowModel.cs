using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFEidos.Models
{
    internal class MainWindowModel : BindableBase
    {
        private Page windowContent;
        public Page WindowContent 
        {
            get { return windowContent; } 
            set { SetProperty(ref windowContent, value); } 
        }

        #region Commands
        public ICommand EmployeesCommand { get; set; }
        public ICommand DepartmentsCommand { get; set; }

        public ICommand OpenFileCommand { get; set; }
        public ICommand SaveFileCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        #endregion

        public MainWindowModel()
        {
            EmployeesCommand = new DelegateCommand(OnEmployeesCommand);
            DepartmentsCommand = new DelegateCommand(OnDepartmentsCommand);

            OpenFileCommand = new DelegateCommand(OnOpenFileCommand);
            SaveFileCommand = new DelegateCommand(OnSaveFileCommand);
            ExitCommand = new DelegateCommand<object>(OnExitCommand);
        }

        private void OnEmployeesCommand()
        {

        }

        private void OnDepartmentsCommand()
        {

        }

        private void OnOpenFileCommand()
        {
            
        }

        private void OnSaveFileCommand()
        {
            
        }

        private void OnExitCommand(object parameter)
        {
            (parameter as Window).Close();
        }
    }
}
