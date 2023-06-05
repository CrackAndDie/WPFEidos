using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;
using WPFEidos.ViewModels;
using WPFEidos.Views;

namespace WPFEidos.Models.Other
{
    internal class WindowHelper
    {
        public static void ShowDepartmentWindow(Department department)
        {
            DepartmentWindowView view = new DepartmentWindowView();
            DepartmentWindowViewModel vm = new DepartmentWindowViewModel(department);
            // not pure mvvm way
            view.Owner = System.Windows.Application.Current.MainWindow;
            view.DataContext = vm;
            view.ShowDialog();
        }

        public static void ShowEmployeeWindow(Employee employee)
        {
            EmployeeWindowView view = new EmployeeWindowView();
            EmployeeWindowViewModel vm = new EmployeeWindowViewModel(employee);
            // not pure mvvm way
            view.Owner = System.Windows.Application.Current.MainWindow;
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
