using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Net.Mime.MediaTypeNames;

namespace KairosScheduler
{
    internal static class Extensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
                return new T[] { item };
            
            T[] result = new T[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }

        public static string getText(this HtmlNode node)
        {
            return Regex.Replace(node.InnerText, @"(^\s+|\s+$)", "");
        }
    }
}
