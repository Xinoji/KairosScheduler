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
            var CicloDictionary = Siiau.GetCicloDictionary();
            var url = "http://consulta.siiau.udg.mx/wco/sspseca.consulta_oferta?" +
                      "ciclop=202310&" + //Ciclo escolar
                      "cup=D&" + //Centro Universitario
                      "majrp=INCO&" +
                      "crsep=&" +
                      "materiap=&" + //Nombre de materia
                      "horaip=&" +
                      "horafp=&" +
                      "edifp=&" +
                      "aulap=&" + 
                      "ordenp=0&" + // Tipo de orden
                      "mostrarp=6000"; //Cantidad Maxima
            var data= Siiau.GetClases(url);
            
            foreach (Clase item in data)
            {
                
                string jsonString = JsonSerializer.Serialize(item);

                if (File.Exists($"{item.Nombre}.json"))
                    File.Delete($"{item.Nombre}.json");

                StreamWriter file = File.AppendText($"{item.Nombre}.json");
                file.WriteLine(jsonString);
                file.Close();
            }
            
        }
       
    }
}