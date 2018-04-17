using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Eventmaker.Model;
using Newtonsoft.Json;

namespace Eventmaker.Persistency
{
    //Notice: NuGet - Json.Net from Newtonsoft is installed, provides: JsonConvert 

    class PersistencyService
    {
        //private static string eventFileName = "EventsAsJson.dat";


        //public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        //{
        //    string eventsJsonString = JsonConvert.SerializeObject(events);
        //    SerializeEventsFileAsync(eventsJsonString, eventFileName);
        //}


        //public static async Task<List<Event>> LoadEventsFromJsonAsync()
        //{
        //    string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
        //    if (eventsJsonString != null)
        //        return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
        //    return null;
        //}

        public static async void SaveEventsAsJsonAsync(Event events)
        {
            const string ServerUrl = "http://localhost:44444";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {                   
                       await client.PostAsJsonAsync("api/events", events);                   
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }           
        }

        public static async void DeleteEventsAsync(Event events)
        {
            const string ServerUrl = "http://localhost:44444";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/events/" + events.Id);
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            const string ServerUrl = "http://localhost:44444";
            HttpClientHandler handler = new HttpClientHandler();
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
                        var eventdata = responce.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        return eventdata.ToList();
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(localFile, eventsString);
        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    try
        //    {
        //        StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //        return await FileIO.ReadTextAsync(localFile);
        //    }
        //    catch (FileNotFoundException ex)
        //    {

        //        MessageDialogHelper.Show("File of Events not found! - Loading for the first time?", "File not found!");
        //        return null;
        //    }
        //}

        //private class MessageDialogHelper
        //{
        //    public static async void Show(string content, string title)
        //    {
        //        MessageDialog messageDialog = new MessageDialog(content, title);
        //        await messageDialog.ShowAsync();
        //    }
        //}


    }


}
