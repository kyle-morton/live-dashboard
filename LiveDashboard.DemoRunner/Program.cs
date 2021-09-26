using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LiveDashboard.DemoRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Thread.Sleep(3000);

                var id = GetRandomId();
                Console.WriteLine($"ID: {id}");

                if (GetAction() == 1)
                {
                    UpdateStatus(id).Wait();
                }
                else
                {
                    UpdateInvoiceStatus(id).Wait();
                }

                Console.WriteLine("Done...");
                Console.WriteLine();

            } while (true);
        }

        private static int GetRandomId()
        {
            return new Random().Next(1, 4);
        }

        private static int GetAction()
        {
            return new Random().Next(1, 3);
        }

        private async static Task UpdateStatus(int id)
        {
            var newStatus = new Random().Next(1, 6);

            Console.WriteLine($"Update Status - ID: {id}, Status: {newStatus}");

            using (var client = new HttpClient())
            {
                var request = new { ShipmentId = id, StatusId = newStatus };

                var json = JsonSerializer.Serialize(request, request.GetType());
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                await client.PutAsync("https://localhost:44337/shipment/status", stringContent);
            }
        }

        private async static Task UpdateInvoiceStatus(int id)
        {
            var newStatus = new Random().Next(1, 4);

            Console.WriteLine($"Update Invoice Status - ID: {id}, Status: {newStatus}");

            using (var client = new HttpClient())
            {
                var request = new { ShipmentId = id, InvoiceStatusId = newStatus };

                var json = JsonSerializer.Serialize(request, request.GetType());
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                await client.PutAsync("https://localhost:44337/shipment/invoicestatus", stringContent);
            }
        }

    }
}
