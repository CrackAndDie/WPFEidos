using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;
using WPFEidos.Models;
using System.Windows.Input;

namespace WPFEidos.ViewModels
{
    internal class DepartmentsPageViewModel
    {
        private DepartmentsPageModel model = new DepartmentsPageModel();

        public ObservableCollection<Department> DepartmentsList => model.Departments;

        public Department SelectedDepartment
        {
            get { return model.SelectedDepartment; }
            set { model.SelectedDepartment = value; }
        }

        #region Commands
        public ICommand AddDepartmentCommand => model.AddDepartmentCommand;
        public ICommand EditDepartmentCommand => model.EditDepartmentCommand;
        public ICommand RemoveDepartmentCommand => model.RemoveDepartmentCommand;
        #endregion
    }
}
