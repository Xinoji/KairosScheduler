using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siiau.Helpers
{
    internal class HtmlUtils
    {
        public static HtmlNode GetWebsiteRootNode(string url)
        {
            //TODO : Validated how the HTML document is recivied when there is an error of connection or any case of access error to make exceptions
            var web = new HtmlWeb();
            var doc = web.Load(url);

            return doc.DocumentNode;
        }

    }
}
