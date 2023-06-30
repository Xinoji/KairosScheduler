using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

namespace KairosScheduler
{
    /// <summary>
    /// Clase para realizar las conexiones y obtener datos de SIIAU.
    /// </summary>
    public static class Siiau
    {
        /// <summary>
        /// Funcion para obtener una unica clase de SIIAU
        /// </summary>
        /// <param name="url">URL con los propios GET implementados </param>
        /// TODO: Pasar por parametro los parametros de GET
        /// <returns></returns>
        public static Clase GetClase(string url)
        {
            Clase materia = new Clase();
            List<ClaseData> clases = new List<ClaseData>();
            ClaseData clase;
            List<Hora> horarios = new List<Hora>();
            Hora horario;

            // TODO: try-catch para error de conexion
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var data = doc.DocumentNode;

            materia.Clave = data.SelectSingleNode("//table[1]/tr[position() > 2]//td[@class='tddatos'][2]").InnerText;
            materia.Nombre = data.SelectSingleNode("//table[1]/tr[position() > 2]//td[@class='tddatos'][3]").InnerText;
            materia.Creditos = byte.Parse(data.SelectSingleNode("//table[1]/tr[position() > 2]//td[@class='tddatos'][5]").InnerText);

            foreach (HtmlNode row in doc.DocumentNode.SelectNodes("/html/table[1]/tr[position() > 2]"))
            {
                try
                {
                    clase = new ClaseData();
                    
                    clase.NRC = int.Parse(row.SelectSingleNode("td[@class='tddatos'][1]").InnerText);
                    clase.Sec = row.SelectSingleNode("td[@class='tddatos'][4]").InnerText;
                    clase.Cupos = byte.Parse(row.SelectSingleNode("td[@class='tddatos'][6]").InnerText);
                    clase.Disponibles = sbyte.Parse(row.SelectSingleNode("td[@class='tddatos'][7]").InnerText);
                    
                    HtmlNode dataHorario = row.SelectSingleNode("td/table[@class='td1']");

                    horarios = new List<Hora>();

                    if (dataHorario.InnerLength != 1)
                        foreach (HtmlNode subHorario in dataHorario.SelectNodes("tr"))
                        {
                            horario = new Hora();

                            string Horas = subHorario.SelectSingleNode("td[2]").InnerText;

                            horario.InitialHour = byte.Parse(Horas.Substring(0, 2));

                            horario.FinalHour = byte.Parse(Horas.Substring(5, 2));
                            string[] dias = subHorario.SelectSingleNode("td[3]").InnerText.Split(" ");

                            for (int index = 0; index < Hora.DIAS; index++)
                            {
                                horario.Days[index] = dias[index] != ".";
                            }

                            horario.Building = subHorario.SelectSingleNode("td[4]").InnerText;
                            horario.Classroom = subHorario.SelectSingleNode("td[5]").InnerText;

                            horarios.Add(horario);

                        }

                    clase.Hora = horarios.ToArray();

                    HtmlNode dataMaestro = row.SelectSingleNode("th|td[last()]//td[@class='tdprofesor'][2]");
                    if (dataMaestro != null)
                        clase.Maestro = dataMaestro.InnerText;

                    clases.Add(clase);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    // Agregar a un archivo log
                }
            }
            materia.Horarios = clases.ToArray();
            return materia;
        }
        
        /// <summary>
        /// Funcion para obtener todas las materias de una Carrera
        /// </summary>
        /// <param name="url"> URL con todos los GET</param>
        /// TODO: pasar solo la carrera
        /// <returns>Array con todas las clases</returns>
        public static Clase[] GetClases(string url)
        {
            List<Clase> materias = new List<Clase>();
            Clase? materia;
            List<ClaseData> clases = new List<ClaseData>();
            ClaseData clase;
            List<Hora> horarios = new List<Hora>();
            Hora horario;

            // TODO: try-catch para error de conexion
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var data = doc.DocumentNode;

            foreach (HtmlNode row in doc.DocumentNode.SelectNodes("/html/table[1]/tr[position() > 2]"))
            {
                try
                {
                    materia = materias.Find(
                        delegate (Clase clase)
                        {
                            return clase.Clave == row.SelectSingleNode("td[@class='tddatos'][2]").InnerText;
                        }
                    );
                    if (materia == null)
                    {
                        materia = new Clase();
                        materia.Clave = row.SelectSingleNode("td[@class='tddatos'][2]").InnerText;
                        materia.Nombre = row.SelectSingleNode("td[@class='tddatos'][3]").InnerText;
                        materia.Creditos = byte.Parse(row.SelectSingleNode("td[@class='tddatos'][5]").InnerText);
                        materias.Add(materia);
                    }

                    clase = new ClaseData();

                    clase.NRC = int.Parse(row.SelectSingleNode("td[@class='tddatos'][1]").InnerText);
                    clase.Sec = row.SelectSingleNode("td[@class='tddatos'][4]").InnerText;
                    clase.Cupos = byte.Parse(row.SelectSingleNode("td[@class='tddatos'][6]").InnerText);
                    clase.Disponibles = sbyte.Parse(row.SelectSingleNode("td[@class='tddatos'][7]").InnerText);

                    HtmlNode dataHorario = row.SelectSingleNode("td/table[@class='td1']");

                    horarios = new List<Hora>();

                    if (dataHorario.InnerLength != 1)
                        foreach (HtmlNode subHorario in dataHorario.SelectNodes("tr"))
                        {
                            horario = new Hora();

                            string Horas = subHorario.SelectSingleNode("td[2]").InnerText;

                            horario.InitialHour = byte.Parse(Horas.Substring(0, 2));

                            horario.FinalHour = byte.Parse(Horas.Substring(5, 2));
                            string[] dias = subHorario.SelectSingleNode("td[3]").InnerText.Split(" ");

                            for (int index = 0; index < Hora.DIAS; index++)
                            {
                                horario.Days[index] = dias[index] != ".";
                            }

                            horario.Building = subHorario.SelectSingleNode("td[4]").InnerText;
                            horario.Classroom = subHorario.SelectSingleNode("td[5]").InnerText;

                            horarios.Add(horario);

                        }

                    clase.Hora = horarios.ToArray();

                    HtmlNode dataMaestro = row.SelectSingleNode("th|td[last()]//td[@class='tdprofesor'][2]");
                    if (dataMaestro != null)
                        clase.Maestro = dataMaestro.InnerText;
                    
                    materia.Horarios = materia.Horarios.Append(clase);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    // Agregar a un archivo log
                }
            }
            return materias.ToArray();
        }

    }
}
