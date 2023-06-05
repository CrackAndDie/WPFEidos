using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Other;

namespace WPFEidos.Models.Classes
{
    public class Employee
    {
        [JsonIgnore]
        private static int lastId => DataHolder.Employees.Count > 0 ? DataHolder.Employees.Max(x => x.Id) : 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleType Role { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department DepartmentObj => DataHolder.Departments.FirstOrDefault(x => x.Employees.Select(e => e.Id).Contains(Id));

        public Employee() : this(lastId + 1) { }

        public Employee(int id)
        {
            Id = id;
        }
    }
}
