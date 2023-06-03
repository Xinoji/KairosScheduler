using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    #region clases
    internal class Clase
    {
        public int NRC { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public List<Horario> Horarios { get; set; }
        public string Maestro { get; set; }
        public string Sec { get; set; }
        public sbyte Creditos { get; set; }
        public sbyte Cupos { get; set; }
        public sbyte Disponibles { get; set; }
        public Clase() 
        {
            Horarios = new List<Horario>();
        }

    }
    internal class Horario
    {
        public const int DIAS = 6;
        public sbyte InitialHour { get; set; }
        public sbyte FinalHour { get; set; }
        public bool[] Days {get; set;}
        public string Building { get; set; }
        public string Classroom { get; set; }
        //public DateOnly InicialDate { get; set; }
        //public DateOnly FinalDate { get; set; }

        public Horario() 
        {
            Days = new bool[6];
        }

    }
    #endregion
}
