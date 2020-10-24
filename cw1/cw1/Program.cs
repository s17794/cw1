using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("podaj adres");
            string adress = Console.ReadLine();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(adress);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-zA-Z0-9]+@+[a-z.]+");
             
                MatchCollection matches = regex.Matches(html);
                foreach (var i in matches)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
