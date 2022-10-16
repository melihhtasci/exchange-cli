using System;
using System.Text;
using System.Text.RegularExpressions;

namespace exchange_cli
{
    public class Helper
    {
        public static string UrlBuilder(string from = "", string to = "", string amount = "")
        {
            StringBuilder stringBuilder = new();

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                stringBuilder.Append(Consts.fromUrl + from);
                stringBuilder.Append(Consts.toUrl + to);
            }
            else
            {
                stringBuilder.Append(Consts.apiUrl + Consts.baseTry);
            }

            if (!string.IsNullOrEmpty(amount))
            { 
                stringBuilder.Append("&amount=" + amount);
            }

            return stringBuilder.ToString();
        }

        public static void Validations(string from, string to, string amount)
        {
            try
            {
                if (!string.IsNullOrEmpty(from))
                    if (!Regex.IsMatch(from, "^[a-zA-Z]+$") || from.Length != 3)
                        throw new Exception("FROM value must be only letter and length must be 3");

                if (!string.IsNullOrEmpty(to))
                    if (!Regex.IsMatch(to, "^[a-zA-Z]+$") || from.Length != 3)
                        throw new Exception("TO value must be only letter and length must be 3");

                if (!string.IsNullOrEmpty(amount))
                {
                    // regex number and number-dot check
                    // throw new Exception("AMOUNT value include just number or number with dot. Example : 23.1");
                }

                ArgumentRules(from, to);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

        }

        public static void ArgumentRules(string from, string to) 
        {
            if (!string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                Console.WriteLine("You must specify to currency to convert it.");
                Console.WriteLine($"Convert from {from.ToUpper()} to what?!");
                MakeLine();
                Environment.Exit(0);
            }
        }

        public static void MakeLine()
        {
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
