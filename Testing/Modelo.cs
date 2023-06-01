using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    #region clases
    internal class Clase
    {
        int NRC { get; set; }
        int clave { get; set; }
        string nombre { get; set; }
        List<Horario> horarios { get; set; }
        string maestro { get; set; }

        Clase() 
        {
            horarios = new List<Horario>();
        }

    }
    internal class Horario 
    { 
        
        
    }
    #endregion
}
