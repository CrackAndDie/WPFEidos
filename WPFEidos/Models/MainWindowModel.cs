using Microsoft.Win32;
using Newtonsoft.Json;
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
using WPFEidos.Models.Other;
using WPFEidos.Views;

namespace WPFEidos.Models
{
    internal class MainWindowModel : BindableBase
    {
        private Page employeesPage = new EmployeesPageView();
        private Page departmentsPage = new DepartmentsPageView();

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
            WindowContent = employeesPage;
        }

        private void OnDepartmentsCommand()
        {
            WindowContent = departmentsPage;
        }

        private void OnOpenFileCommand()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse JSON File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if ((bool)openFileDialog.ShowDialog())
            {
                DataManager.LoadFromFile(openFileDialog.FileName);
            }
        }

        private void OnSaveFileCommand()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON file (*.json)|*.json",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                ValidateNames = true,
                OverwritePrompt = true,
                AddExtension = true
            };
            if ((bool)saveFileDialog.ShowDialog())
            {
                DataManager.SaveToFile(saveFileDialog.FileName);
            }
        }

        private void OnExitCommand(object parameter)
        {
            (parameter as Window).Close();
        }
    }
}
