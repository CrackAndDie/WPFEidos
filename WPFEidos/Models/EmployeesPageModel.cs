using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFEidos.Models.Classes;
using WPFEidos.Models.Other;

namespace WPFEidos.Models
{
    internal class EmployeesPageModel : BindableBase
    {
        public ObservableCollection<Employee> Employees => DataHolder.Instance.Employees;

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { SetProperty(ref selectedEmployee, value); }
        }

        #region Commands
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }
        #endregion

        public EmployeesPageModel()
        {
            AddEmployeeCommand = new DelegateCommand(OnAddEmployeeCommand);
            EditEmployeeCommand = new DelegateCommand(OnEditEmployeeCommand);
            RemoveEmployeeCommand = new DelegateCommand(OnRemoveEmployeeCommand);
        }

        private void OnAddEmployeeCommand()
        {
            var emp = new Employee();
            WindowHelper.ShowEmployeeWindow(emp);
        }

        private void OnEditEmployeeCommand()
        {
            if (SelectedEmployee != null)
            {
                WindowHelper.ShowEmployeeWindow(SelectedEmployee);
                return;
            }
            MessageBox.Show("Select employee to edit");
        }

        private void OnRemoveEmployeeCommand()
        {
            if (SelectedEmployee != null)
            {
                DataHolder.Instance.Employees.Remove(SelectedEmployee);
                return;
            }
            MessageBox.Show("Select employee to remove");
        }
    }
}
