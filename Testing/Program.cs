using System;
using System.Diagnostics;
using System.Text.Json;
using System.Xml;
using HtmlAgilityPack;
using KairosScheduler;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var url = "http://consulta.siiau.udg.mx/wco/sspseca.consulta_oferta?ciclop=202310&cup=D&majrp=INCO&crsep=&materiap=&horaip=&horafp=&edifp=&aulap=&ordenp=0&mostrarp=6000";
            var data = Siiau.GetClases(url);
            
            foreach (Clase item in data)
            {
                
                string jsonString = JsonSerializer.Serialize(item);

                if (File.Exists($"{item.Nombre}.json"))
                    File.Delete($"{item.Nombre}.json");

                var file = File.AppendText($"{item.Nombre}.json");
                file.WriteLine(jsonString);
                file.Close();
            }
            
        }
       
    }
}