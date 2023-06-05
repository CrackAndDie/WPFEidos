using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFEidos.Models;
using WPFEidos.Models.Classes;
using WPFEidos.Models.Other;

namespace WPFEidos.ViewModels
{
    internal class EmployeesPageViewModel : BindableBase
    {
        private EmployeesPageModel model = new EmployeesPageModel();

        public ObservableCollection<Employee> EmployeesList => model.Employees;

        public Employee SelectedEmployee
        {
            get { return model.SelectedEmployee; }
            set { model.SelectedEmployee = value; }
        }

        #region Commands
        public ICommand AddEmployeeCommand => model.AddEmployeeCommand;
        public ICommand EditEmployeeCommand => model.EditEmployeeCommand;
        public ICommand RemoveEmployeeCommand => model.RemoveEmployeeCommand;
        #endregion
    }
}
