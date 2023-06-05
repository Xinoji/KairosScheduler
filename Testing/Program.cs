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
            var url = "http://consulta.siiau.udg.mx/wco/sspseca.consulta_oferta?ciclop=202310&cup=D&majrp=INCO&crsep=I7025&materiap=&horaip=&horafp=&edifp=&aulap=&ordenp=0&mostrarp=100";
            var data = Siiau.GetClase(url);
            string jsonString = JsonSerializer.Serialize(data);

            if (File.Exists("test.json"))
                File.Delete("test.json");

            var file = File.AppendText("test.json");
            file.WriteLine(jsonString);
            file.Close();
        }
       
    }
}