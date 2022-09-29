using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exchange_cli
{
    public static class Consts
    {
        public const string apiUrl = "https://api.exchangerate.host/latest";
        public const string fromUrl = "https://api.exchangerate.host/convert?from=";
        public const string toUrl = "&to=";
        public const string baseTry = "?base=TRY";
        public const string TRY = "TRY";
        public const string EUR = "EUR";
        public const string USD = "USD";
    }
}
