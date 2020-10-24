using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (adress is null)
            {
                throw new System.ArgumentNullException("adress");
              
            }
            if ((adress.StartsWith("https://") || adress.StartsWith("http://")) == false)
            {
                throw new System.ArgumentException("Niepoprawny format adresu");
               
            }
           
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(adress);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-zA-Z0-9]+@+[a-z.]+");

                MatchCollection matches = regex.Matches(html);
                
                if (matches.Count == 0)
                {
                    Console.WriteLine("Nie znaleziono zadresów email");
                }
                else
                {
                    var distmatches = matches.Select(dist => dist.Groups[0].Value).Distinct();
                    foreach (var i in distmatches)
                    {

                        Console.WriteLine(i);
                    }
                }
                
            }
            else 
            {
               Console.WriteLine("Bład w czasie pobierania strony");
            }
            httpClient.Dispose();
        
        }
    }

}
