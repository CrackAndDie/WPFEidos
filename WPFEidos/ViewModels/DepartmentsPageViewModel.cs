using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;
using WPFEidos.Models;

namespace WPFEidos.ViewModels
{
    internal class DepartmentsPageViewModel
    {
        private DepartmentsPageModel model = new DepartmentsPageModel();

        public ObservableCollection<Department> DepartmentsList => model.Departments;
    }
}
