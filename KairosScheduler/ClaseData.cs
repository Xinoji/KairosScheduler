using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KairosScheduler
{
    public class ClaseData
    {
        public int NRC { get; set; }
        public string Maestro { get; set; }
        public string Sec { get; set; }
        public byte Cupos { get; set; }
        public sbyte Disponibles { get; set; }
        public Hora[] Hora { get; set; }

        public ClaseData() 
        { 
            Hora = new Hora[0];
        }
    }

}
