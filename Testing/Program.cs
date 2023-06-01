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
                Console.WriteLine("Found: " + table.Id);
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    Console.WriteLine("row");
                    foreach (HtmlNode cell in row.SelectNodes("th|td[@class='tddatos']"))
                    {
                        Console.WriteLine("cell: " + cell.InnerText);
                    }
                }
            
        }
    }
}