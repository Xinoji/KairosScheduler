using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace KairosScheduler
{
    public class UNAM
    {
        public class Clase
        { 
            public int Clave;
            public string Grupo;
            public string Nombre;
            public (int HoraInicial, int HoraFinal)[] Horario;
            public string Maestro;

            private Clase()
            {
                Horario = new (int HoraInicial, int HoraFinal)[6];
            }

            public Clase(int clave, string grupo, string nombre, (int HoraInicial, int HoraFinal)[] horario, string maestro)
            {
                Clave = clave;
                Grupo = grupo;
                Nombre = nombre;
                Maestro = maestro;
                Horario = horario;
            }
        }

        public static void GetClases()
        {
            //Tupla Semestre, Grupo
            List<(string Grupo, int Semestre)> Grupos = new List<(string Grupo, int Semestre)>();
            List<Clase> Clases = new List<Clase>();

            // TODO: try-catch para error de conexion

            var doc = new HtmlDocument();
            doc.Load(path:Console.In.ReadLine());
            HtmlNode? data = doc.DocumentNode;

            foreach (HtmlNode row in data.SelectNodes("//tr[position() > 2]"))
            {
                if (row.InnerText == "")
                    continue;

                if (row.ChildNodes[0].InnerText != "")
                    Grupos.Add(CreateGrupo(row.ChildNodes));
                else
                    Clases.Add(CreateClase(row.ChildNodes, Grupos.Last().Grupo));
                
            }

        }

        private static Clase CreateClase(HtmlNodeCollection childNodes, string grupo)
        {
            string[] separador = { " y " }; 
            (int HoraInicial, int HoraFinal)[] Horario = new (int HoraInicial, int HoraFinal)[6];
            int diaIndex = 0;

            foreach (var HorarioCrudo in childNodes[3].getText().Split(separador, StringSplitOptions.None))
            {
                var DatosHorario = HorarioCrudo.Split("a ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries); 

                foreach (string dia in DatosHorario[0].Split(','))
                {
                    switch (dia)
                    {
                        case "LU": diaIndex = 0; break;
                        case "MA": diaIndex = 1; break;
                        case "MI": diaIndex = 2; break;
                        case "JU": diaIndex = 3; break;
                        case "VI": diaIndex = 4; break;
                        case "SA": diaIndex = 5; break;
                        default: throw new Exception("DIA NO RECONOCIDO");
                    }

                    Horario[diaIndex] = (int.Parse(DatosHorario[1].Split(':')[0]), 
                                        int.Parse(DatosHorario[2].Split(':')[0]));
                }

            }
            

            return new Clase(clave: int.Parse(childNodes[1].getText()),
                        grupo: grupo,
                        nombre: childNodes[2].getText(),
                        horario: Horario.ToArray(),
                        maestro: childNodes[4].getText())
            {

            };
        }

        private static (string Grupo, int Semestre) CreateGrupo(HtmlNodeCollection childNodes)
        {
            return (childNodes[2].getText().Split(' ')[1],
                   int.Parse(childNodes[1].getText().Split(' ')[1]));
        }
    }
}
