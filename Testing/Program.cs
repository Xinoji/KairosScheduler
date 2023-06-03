using System;
using System.Diagnostics;
using System.Text.Json;
using System.Xml;
using HtmlAgilityPack;


namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Clase> clases = new List<Clase>();
            Clase clase;
            Horario horario;
            var path = @"test.html";

            var doc = new HtmlDocument();
            doc.Load(path);
            var tables = doc.DocumentNode.SelectNodes("//table[1]//tbody");
            var table = tables.First();
            Console.WriteLine("Found: " + table.XPath);


            foreach (HtmlNode row in table.SelectNodes("tr[position() > 2]"))
            {
                clase = new Clase();

                clase.NRC       =   int.Parse(  row.SelectSingleNode("th|td[@class='tddatos'][1]").InnerText);
                clase.Clave     =               row.SelectSingleNode("th|td[@class='tddatos'][2]").InnerText;
                clase.Nombre    =               row.SelectSingleNode("th|td[@class='tddatos'][3]").InnerText;
                clase.Sec       =               row.SelectSingleNode("th|td[@class='tddatos'][4]").InnerText;
                clase.Creditos  =   sbyte.Parse(row.SelectSingleNode("th|td[@class='tddatos'][5]").InnerText);
                clase.Cupos     =   sbyte.Parse(row.SelectSingleNode("th|td[@class='tddatos'][6]").InnerText);
                clase.Disponibles = sbyte.Parse(row.SelectSingleNode("th|td[@class='tddatos'][7]").InnerText);

                HtmlNode dataHorario = row.SelectSingleNode("th|td/table[@class='td1']");

                if (dataHorario.InnerLength != 1)
                    foreach (HtmlNode subHorario in dataHorario.SelectNodes("tbody/tr"))
                    {
                        horario = new Horario();
                        
                        string Hora = subHorario.SelectSingleNode("td[2]").InnerText;
                        
                        horario.InitialHour = sbyte.Parse(Hora.Substring(0,2));
                        
                        horario.FinalHour = sbyte.Parse(Hora.Substring(5,2));
                        string[] dias = subHorario.SelectSingleNode("td[3]").InnerText.Split(" ");

                        for (int index = 0; index < Horario.DIAS; index++)
                        {
                            horario.Days[index] = dias[index] != ".";
                        }

                        horario.Building = subHorario.SelectSingleNode("td[4]").InnerText;
                        horario.Classroom = subHorario.SelectSingleNode("td[5]").InnerText;

                        clase.Horarios.Add(horario);
                    }


                HtmlNode dataMaestro = row.SelectSingleNode("th|td[last()]//td[@class='tdprofesor'][2]");
                if (dataMaestro != null)
                    clase.Maestro = dataMaestro.InnerText;

                clases.Add(clase);
            }
            string jsonString = JsonSerializer.Serialize(clases);

            if (File.Exists("test.json"))
                File.Delete("test.json");

            var file = File.AppendText("test.json");
            file.WriteLine(jsonString);
            file.Close();
        }
    }
}