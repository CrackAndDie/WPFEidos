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
        private static int lastId => DataHolder.Rooms.Count > 0 ? DataHolder.Rooms.Max(x => x.Id) : 0;
        public int Id { get; set; }
        public int RoomNumber { get; set; } 
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Department DepartmentObj => DataHolder.Departments.FirstOrDefault(x => x.Rooms.Select(e => e.Id).Contains(Id));

        public Room() : this(lastId + 1) { }

        public Room(int id)
        {
            Id = id;
        }
    }
}
