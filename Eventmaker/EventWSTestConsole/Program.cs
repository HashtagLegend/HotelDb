using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EventWS;
using EventWS.Controllers;

namespace EventWSTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ServerUrl = "http://localhost:44444";
            HttpClientHandler handler=new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
               client.BaseAddress = new Uri(ServerUrl);
               client.DefaultRequestHeaders.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var responce = client.GetAsync("api/events").Result;
                    if (responce.IsSuccessStatusCode)
                    {
                        IEnumerable<Event> eventData = responce.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        foreach (var e in eventData)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}
