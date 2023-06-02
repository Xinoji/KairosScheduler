using System;
using System.Xml;
using HtmlAgilityPack;


namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"test.html";

            var doc = new HtmlDocument();
            doc.Load(path);
            var tables = doc.DocumentNode.SelectNodes("//table[1]//tbody");
            var table = tables.First();
            Console.WriteLine("Found: " + table.XPath);
            foreach (HtmlNode row in table.SelectNodes("tr[position() > 2]"))
            {
                Console.WriteLine("row: " + row.XPath);
                foreach (HtmlNode cell in row.SelectNodes("th|td[@class='tddatos'][last()>position()]"))
                {
                    Console.WriteLine("cell: " + cell.InnerText);
                }
                HtmlNode dataMaestro = row.SelectNodes("th|td[last()]//td[@class='tdprofesor']").First();



                HtmlNode dataHorario = row.SelectNodes("th|td/table[@class='td1']").First();

                if (dataHorario.InnerLength == 1)
                    continue;

                foreach (HtmlNode subHorario in dataHorario.SelectNodes("tbody/tr"))
                {
                    Console.WriteLine("cell: " + subHorario.XPath);

                    foreach (HtmlNode cell in subHorario.SelectNodes("td"))
                    {
                        Console.WriteLine("cell: " + cell.InnerText);
                    }
                }

            }
            
        }
    }
}