using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPFEidos.Models;
using WPFEidos.Models.Classes;

namespace WPFEidos.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private MainWindowModel model = new MainWindowModel();

        public Page WindowContent => model.WindowContent;

        #region Commands
        public ICommand EmployeesCommand => model.EmployeesCommand;
        public ICommand DepartmentsCommand => model.DepartmentsCommand;

        public ICommand OpenFileCommand => model.OpenFileCommand;
        public ICommand SaveFileCommand => model.SaveFileCommand;
        public ICommand ExitCommand => model.ExitCommand;
        #endregion

        public MainWindowViewModel()
        {
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
        }
    }
}
