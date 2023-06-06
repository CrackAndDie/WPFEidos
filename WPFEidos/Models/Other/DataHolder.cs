using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Classes;

namespace WPFEidos.Models.Other
{
    internal class DataHolder
    {
        // singleton
        [JsonIgnore]
        private static DataHolder instance;
        [JsonIgnore]
        public static DataHolder Instance 
        { 
            get 
            { 
                if (instance == null)
                    instance = new DataHolder();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        public ObservableCollection<Department> Departments = new ObservableCollection<Department>();

        public ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
    }
}
