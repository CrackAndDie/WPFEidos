using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;
using WPFEidos.Models.Other;

namespace WPFEidos.Models
{
    internal class DepartmentsPageModel
    {
        public ObservableCollection<Department> Departments => DataHolder.Departments;
    }
}
