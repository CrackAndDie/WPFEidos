using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Other;

namespace WPFEidos.Models.Classes
{
    public class Department
    {
        [JsonIgnore]
        private static int lastId => DataHolder.Departments.Count > 0 ? DataHolder.Departments.Max(x => x.Id) : 0;
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Room> Rooms => DataHolder.Rooms.Where(x => x.DepartmentId == Id).ToList();
        [JsonIgnore]
        public List<Employee> Employees => DataHolder.Employees.Where(x => x.DepartmentId == Id).ToList();

        public Department() : this(lastId + 1) { }

        public Department(int id)
        {
            Id = id;
        }
    }
}
