using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "http://localhost:52715/api/saludo";

        HttpResponseMessage response = await client.GetAsync(url);
        string resultado = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Respuesta del Web Service: {resultado}");
    }
}
