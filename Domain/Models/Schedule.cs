using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public string? Teacher { get; set; }
        public string? Sector { get; set; }
        public byte Cupos { get; set; }
        public sbyte Disponibles { get; set; }
    }
}
