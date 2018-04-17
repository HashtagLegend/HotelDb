using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelDbWebService;

namespace HotelWebServiceRest
{
    class Program
    {
        static void Main(string[] args)
        {

            const string ServerUrl = "http://localhost:50000";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //Laver en get på alle hoteller og udskriver dem
                    var response = client.GetAsync("api/GuestLists").Result;

                    if(response.IsSuccessStatusCode)

                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        foreach (var hotel in hotels)
                        {
                            Console.WriteLine(hotel);
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    throw;
                }
            }
            Console.ReadKey();
        }
        
    }
}
