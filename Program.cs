using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace exchange_cli
{
    [Command(Name = "rate", Description = "Shows current exchange value. Turkish currency is TRY")]
    [HelpOption("--h")]
    public class Program
    {
        [Argument(0, Description = "First arguemnt. Convert exchange from ... (3 letters)")]
        public string From { get; }

        [Argument(1, Description = "Second argument. Exchange to ... (3 letters)")]
        public string To { get; }

        [Argument(2, Description = "Third argument. Exchange amount ... (##.##)")]
        public static string Amount { get; set; }

        static List<string> currencyList = new List<string>();
        static HttpClient client = new HttpClient();

        static Task<int> Main(string[] args) => CommandLineApplication.ExecuteAsync<Program>(args);

        private async Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken = default)
        {
            Helper.MakeLine();
            Helper.Validations(From, To, Amount);
            await GetCurrencies(From, To, Amount);
            GetCurrencyValue(From, To);
            Helper.MakeLine();
            return 1;
        }

        static async Task GetCurrencies(string from = "", string to = "", string amount = "")
        {
            var url = Helper.UrlBuilder(from, to, amount);
            var response = client.GetStreamAsync(url);
            var exchange = await JsonSerializer.DeserializeAsync<Exchange>(await response);

            if (exchange.success)
            {
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    WriteExchangeResults(exchange);
                }
                else
                {
                    ConvertResultToListViaReflection(exchange);
                }
            }
            else
            {
                Console.WriteLine("Exchange API is not active right now, sorry :(");
                Environment.Exit(0);
            }


        }

        private static void ConvertResultToListViaReflection(Exchange exchange)
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

        static void WriteExchangeResults(Exchange exchange) 
        {
            if (exchange.info.rate.Equals(null))
            {
                // api returns success but some values are null 
                // so i can understand parameters can be wrong
                Console.WriteLine("Exchange parameters can be wrong.");
                Environment.Exit(0);
            }
            StringBuilder stringBuilder = new();
            stringBuilder.Append($"{exchange.query.from}: {exchange.query.amount}\t\t");
            stringBuilder.Append($"{exchange.query.to}: {exchange.result}\t\t");
            stringBuilder.Append($"Rate: {exchange.info.rate}");

            Console.WriteLine(stringBuilder.ToString());
            Environment.Exit(0);
            
        }

        static void GetCurrencyValue(string from, string to)
        {
            string line = "";
            // this condition for turkish guys like me. because of poor economy :(
            // just shows 1 usd and eur value opposing tl
            if (string.IsNullOrEmpty(from) && string.IsNullOrEmpty(to))
            {
                float usd = GetCurrencyBySplit(Consts.USD);
                float eur = GetCurrencyBySplit(Consts.EUR);

                line += Consts.USD + ":" + (1 / usd) + "\t\t";
                line += Consts.EUR + ":" + (1 / eur) + "\t\t";
            }
            Console.WriteLine(line);
        }

        static float GetCurrencyBySplit(string currency)
        {
            float valueOfCurrency = ParseCurrencyAndValue(currency);

            if (!string.IsNullOrEmpty(Amount))
            {
                return float.Parse(Amount, CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                return valueOfCurrency;
            }
        }

        private static float ParseCurrencyAndValue(string currency)
        {
            string nameAndValue = currencyList.Where(x => x.Contains(currency.ToUpper())).FirstOrDefault().ToString();
            float valueOfCurrency = float.Parse(nameAndValue.Split('-')[1]); // exmp USD-14.23
            return valueOfCurrency;
        }


    }

}




