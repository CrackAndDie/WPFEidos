using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WPFEidos.Models.Classes;

namespace WPFEidos.Models.Other
{
    internal static class DataManager
    {
        public static void AddDefaultData()
        {
            DataHolder.Instance.Employees.Add(new Employee() { Name = "Ivan", Surname = "Ivanov", Role = RoleType.Junior, Salary = 30000, DepartmentId = 1, });
            DataHolder.Instance.Employees.Add(new Employee() { Name = "Egor", Surname = "Egorov", Role = RoleType.Middle, Salary = 80000, DepartmentId = 1, });
            DataHolder.Instance.Employees.Add(new Employee() { Name = "Petr", Surname = "Petrov", Role = RoleType.Senior, Salary = 130000, });

            DataHolder.Instance.Departments.Add(new Department(1) { Name = "Main Department", Address = "Pushkina, 15" });

            DataHolder.Instance.Rooms.Add(new Room() { RoomNumber = 1, DepartmentId = 1, });
            DataHolder.Instance.Rooms.Add(new Room() { RoomNumber = 2, DepartmentId = 1, });
            DataHolder.Instance.Rooms.Add(new Room() { RoomNumber = 3 });
            DataHolder.Instance.Rooms.Add(new Room() { RoomNumber = 4 });
            DataHolder.Instance.Rooms.Add(new Room() { RoomNumber = 5 });
        }

        public static void LoadFromFile(string fileName)
        {
            string text = File.ReadAllText(fileName);
            DataHolder dh = JsonConvert.DeserializeObject<DataHolder>(text);
            DataHolder.SetNewData(dh);
        }

        public static void SaveToFile(string fileName)
        {
            var dataString = JsonConvert.SerializeObject(DataHolder.Instance);
            File.WriteAllText(fileName, dataString);
        }
    }
}
