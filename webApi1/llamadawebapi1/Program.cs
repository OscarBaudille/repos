using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace llamadawebapi1
{
    class Program
    {
        static async Task Main()
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:52715/api/saludo";

            HttpResponseMessage response = await client.GetAsync(url);
            string resultado = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Respuesta del Web Service: {resultado}");
            Console.WriteLine("");
            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();

        }
    }
}
