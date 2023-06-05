using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KairosScheduler
{
    public class Hora
    {
        public const int DIAS = 6;
        public byte InitialHour { get; set; }
        public byte FinalHour { get; set; }
        public bool[] Days { get; set; }
        public string Building { get; set; }
        public string Classroom { get; set; }
        //public DateOnly InicialDate { get; set; }
        //public DateOnly FinalDate { get; set; }

        public Hora()
        {
            Days = new bool[6];
        }
    }
}
