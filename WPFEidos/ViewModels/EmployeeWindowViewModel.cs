using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;
using WPFEidos.Models;
using System.Windows.Input;
using WPFEidos.Models.Other;

namespace WPFEidos.ViewModels
{
    internal class EmployeeWindowViewModel : BindableBase
    {
        private EmployeeWindowModel model;

        public string Name
        {
            get { return model.Name; }
            set { model.Name = value; }
        }

        public string Surname
        {
            get { return model.Surname; }
            set { model.Surname = value; }
        }

        public int Salary
        {
            get { return model.Salary; }
            set { model.Salary = value; }
        }

        public ObservableCollection<Department> AvailableDepartments
        {
            get { return model.AvailableDepartments; }
            set { model.AvailableDepartments = value; }
        }

        public Department NewSelectedDepartment
        {
            get { return model.NewSelectedDepartment; }
            set { model.NewSelectedDepartment = value; }
        }

        public ObservableCollection<RoleType> AvailableRoles
        {
            get { return model.AvailableRoles; }
            set { model.AvailableRoles = value; }
        }

        public RoleType NewSelectedRole
        {
            get { return model.NewSelectedRole; }
            set { model.NewSelectedRole = value; }
        }

        #region Commands
        public ICommand SaveCommand => model.SaveCommand;
        #endregion

        public EmployeeWindowViewModel(Employee employee)
        {
            model = new EmployeeWindowModel(employee);
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
        }
    }
}
