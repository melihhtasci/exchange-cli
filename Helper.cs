using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchange_cli
{
    public class Helper
    {
        public static string UrlBuilder(string fromExchange="", string amount="")
        {
            string url = string.Empty;

            if (!string.IsNullOrEmpty(fromExchange))
                url += Consts.apiUrl + "?base=" + fromExchange;
            else
                url += Consts.apiUrl + Consts.baseTry;

            if (!string.IsNullOrEmpty(amount))
                url += "&amount=" + amount;

            return url;
        }

        public static void MakeLine()
        {
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
