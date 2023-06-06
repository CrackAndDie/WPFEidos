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
    internal class EmployeeWindowModel : BindableBase
    {
        public ObservableCollection<Department> AvailableDepartments;
        public ObservableCollection<RoleType> AvailableRoles;

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value); }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { SetProperty(ref salary, value); }
        }

        private Department newSelectedDepartment;
        public Department NewSelectedDepartment
        {
            get { return newSelectedDepartment; }
            set { SetProperty(ref newSelectedDepartment, value); }
        }

        private RoleType newSelectedRole;
        public RoleType NewSelectedRole
        {
            get { return newSelectedRole; }
            set { SetProperty(ref newSelectedRole, value); }
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { SetProperty(ref currentEmployee, value); }
        }

        #region Commands
        public ICommand SaveCommand { get; set; }
        #endregion

        public EmployeeWindowModel(Employee employee) 
        {
            CurrentEmployee = employee;

            AvailableRoles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>().ToObservableCollection();
            AvailableDepartments = DataHolder.Instance.Departments;

            NewSelectedRole = CurrentEmployee.Role;
            NewSelectedDepartment = CurrentEmployee.DepartmentObj;

            // could be used directly to binding but I don't care :)
            Name = employee.Name;
            Surname = employee.Surname;
            Salary = employee.Salary;

            SaveCommand = new DelegateCommand<object>(OnSaveCommand);
        }

        private void OnSaveCommand(object parameter)
        {
            var exists = DataHolder.Instance.Employees.Contains(CurrentEmployee);
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            if (string.IsNullOrEmpty(Surname))
            {
                MessageBox.Show("Surname cannot be empty");
                return;
            }
            if (Salary <= 0)
            {
                MessageBox.Show("Salary cannot be zero or less");
                return;
            }
            CurrentEmployee.Name = Name;
            CurrentEmployee.Surname = Surname;
            CurrentEmployee.Salary = Salary;
            CurrentEmployee.Role = NewSelectedRole;
            CurrentEmployee.DepartmentId = NewSelectedDepartment != null ? NewSelectedDepartment.Id : 0;

            if (!exists)
            {
                DataHolder.Instance.Employees.Add(CurrentEmployee);
            }
            CurrentEmployee.RaiseChanged();
            (parameter as Window).Close();
        }
    }
}
