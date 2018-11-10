using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace restconnector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = "https://jsonplaceholder.typicode.com/posts/1";
                    var response = httpClient.GetAsync(url).Result;
                    string jsonResult = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(jsonResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
