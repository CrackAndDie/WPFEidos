using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;

namespace WPFEidos.Models.Other
{
    internal static class DataHolder
    {
        public static ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        public static ObservableCollection<Department> Departments = new ObservableCollection<Department>();

        public static ObservableCollection<Room> Rooms = new ObservableCollection<Room>();

        static DataHolder()
        {
            AddDefaultData();
        }

        private static void AddDefaultData()
        {
            Employees.Add(new Employee() { Name = "Egor", Surname = "Aksenov", Role = RoleType.Junior, Salary = 30000, DepartmentId = 1, });
            Employees.Add(new Employee() { Name = "Askar", Surname = "Shpalitov", Role = RoleType.Middle, Salary = 80000, DepartmentId = 1, });

            Departments.Add(new Department(1) { Name = "Main Department" });

            Rooms.Add(new Room() { RoomNumber = 1, DepartmentId = 1, });
            Rooms.Add(new Room() { RoomNumber = 2, DepartmentId = 1, });
            Rooms.Add(new Room() { RoomNumber = 3 });
            Rooms.Add(new Room() { RoomNumber = 4 });
            Rooms.Add(new Room() { RoomNumber = 5 });
        }
    }
}
