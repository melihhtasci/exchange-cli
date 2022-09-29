using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace exchange_cli
{
    [Command(Name = "rate", Description = "Shows current exchange value. Turkish currency is TRY")]
    [HelpOption("--h")]
    public class Program
    {
        [Option("--fr", Description = " Convert exchange from ... (3 letters)")]
        public string From { get; }

        [Option("--to", Description = "Exchange to ... (3 letters)")]
        public string To { get; }

        [Option("--am", Description = "Exchange amount ... (##.##)")]
        public static string Amount { get; set; }


        static List<string> currencyList = new List<string>();
        static HttpClient client = new HttpClient();

        static Task<int> Main(string[] args) => CommandLineApplication.ExecuteAsync<Program>(args);

        private async Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken = default)
        {
            Helper.MakeLine();
            Validations(From, To, Amount);
            await GetCurrencies(From, To, Amount);
            GetCurrencyValue(From, To);
            Helper.MakeLine();
            return 1;
        }

        static async Task GetCurrencies(string fromExchange = "", string toExchange = "", string amount = "")
        {
            var response = client.GetStreamAsync(Helper.UrlBuilder(fromExchange, amount));
            var exchange = await JsonSerializer.DeserializeAsync<Exchange>(await response);

            if (exchange.success)
            {
                // convert to list via reflection
                List<string> currencies = exchange.rates.GetType().GetProperties()
                    .Select(cur =>
                    {
                        object value = cur.GetValue(exchange.rates, null);
                        value = value == null ? "###" : value.ToString();
                        return (cur.Name + '-' + value.ToString());
                    }).ToList();

                // transfer to static list for access
                currencyList = currencies;
            }
            else
            {
                Console.WriteLine("Exchange API is not active right now, sorry :(");
                Environment.Exit(0);
            }


        }

        static void GetCurrencyValue(string from, string to)
        {
            string line = "";
            if (string.IsNullOrEmpty(from))
            {
                line += Consts.TRY + ":1.00\t\t";
            }
            else
            {
                line += from.ToUpperInvariant() + ":1.00\t\t";
            }

            if (string.IsNullOrEmpty(to))
            {
                string usd = GetCurrencyBySplit(Consts.USD);
                string eur = GetCurrencyBySplit(Consts.EUR);

                line += Consts.USD + ":" + usd + "\t\t";
                line += Consts.EUR + ":" + eur + "\t\t";
            }
            else
            {
                string toValue = GetCurrencyBySplit(to);
                line += to.ToUpper() + ":" + toValue + "\t\t";
            }

            Console.WriteLine(line);
        }

        static string GetCurrencyBySplit(string currency)
        {
            string nameAndValue = currencyList.Where(x => x.Contains(currency.ToUpper())).FirstOrDefault().ToString();
            float valueOfCurrency = float.Parse(nameAndValue.Split('-')[1]); // exmp USD-14.23

            // sub conditions are for penny 
            // i didnt want to show like XYZ:1    ACD:0.121

            if (!string.IsNullOrEmpty(Amount))
            {
                float amountValue = float.Parse(Amount, CultureInfo.InvariantCulture.NumberFormat);

                if (valueOfCurrency > 1)
                    return (valueOfCurrency).ToString().Replace(",", ".");

                else
                    return ((amountValue / valueOfCurrency) * amountValue).ToString().Replace(",", ".");

            }
            else
            {

                if (valueOfCurrency > 1)
                    return valueOfCurrency.ToString().Replace(",", ".");
                else
                    return (1 / valueOfCurrency).ToString().Replace(",", ".");
            }

        }

        static void Validations(string from, string to, string amount)
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

        }

    }

}




