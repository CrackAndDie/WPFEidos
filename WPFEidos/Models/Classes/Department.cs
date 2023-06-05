using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Other;

namespace WPFEidos.Models.Classes
{
    public class Department : BindableBase
    {
        [JsonIgnore]
        private static int lastId => DataHolder.Departments.Count > 0 ? DataHolder.Departments.Max(x => x.Id) : 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public List<Room> Rooms => DataHolder.Rooms.Where(x => x.DepartmentId == Id).ToList();
        [JsonIgnore]
        public List<Employee> Employees => DataHolder.Employees.Where(x => x.DepartmentId == Id).ToList();

        public Department() : this(lastId + 1) { }

        public Department(int id)
        {
            Id = id;
        }

        public void RaiseChanged(bool fromEmployee = false)
        {
            RaisePropertyChanged("Rooms");
            RaisePropertyChanged("Employees");
            if (!fromEmployee)
            {
                foreach (var e in Employees)
                {
                    e.RaiseChanged();
                }
            }
        }
    }
}
