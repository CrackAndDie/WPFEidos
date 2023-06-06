using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEidos.Models.Other;

namespace WPFEidos.Models.Classes
{
    public class Room
    {
        [JsonIgnore]
        private static int lastId => DataHolder.Instance.Rooms.Count > 0 ? DataHolder.Instance.Rooms.Max(x => x.Id) : 1;
        public int Id { get; set; }
        public int RoomNumber { get; set; } 
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department DepartmentObj => DataHolder.Instance.Departments.FirstOrDefault(x => x.Rooms.Select(e => e.Id).Contains(Id));

        public Room() : this(lastId + 1) { }

        public Room(int id)
        {
            Id = id;
        }
    }
}
