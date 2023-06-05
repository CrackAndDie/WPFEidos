using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;

namespace WPFEidos.Models.Other
{
    internal class DataHolder
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            // new Employee() { Name = "Egor", Surname = "Aksenov", Role = RoleType.Junior, Salary = 30000,  }
        };

        public static List<Department> Departments = new List<Department>()
        {

        };

        public static List<Room> Rooms = new List<Room>()
        {

        };
    }
}
