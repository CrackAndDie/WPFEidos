using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFEidos.Models.Classes;
using WPFEidos.Models.Other;

namespace WPFEidos.Models
{
    internal class DepartmentsPageModel : BindableBase
    {
        public ObservableCollection<Department> Departments => DataHolder.Instance.Departments;

        private Department selectedDepartment;
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set { SetProperty(ref selectedDepartment, value); }
        }

        #region Commands
        public ICommand AddDepartmentCommand { get; set; }
        public ICommand EditDepartmentCommand { get; set; }
        public ICommand RemoveDepartmentCommand { get; set; }
        #endregion

        public DepartmentsPageModel() 
        {
            AddDepartmentCommand = new DelegateCommand(OnAddDepartmentCommand);
            EditDepartmentCommand = new DelegateCommand(OnEditDepartmentCommand);
            RemoveDepartmentCommand = new DelegateCommand(OnRemoveDepartmentCommand);
        }

        private void OnAddDepartmentCommand()
        {
            var dep = new Department();
            WindowHelper.ShowDepartmentWindow(dep);
        }

        private void OnEditDepartmentCommand()
        {
            if (SelectedDepartment != null)
            {
                WindowHelper.ShowDepartmentWindow(SelectedDepartment);
                return;
            }
            MessageBox.Show("Select department to edit");
        }

        private void OnRemoveDepartmentCommand()
        {
            if (SelectedDepartment != null)
            {
                DataHolder.Instance.Departments.Remove(SelectedDepartment);
                return;
            }
            MessageBox.Show("Select department to remove");
        }
    }
}
