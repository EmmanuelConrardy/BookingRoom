using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            Console.WriteLine("Booking programme Started on port 8080");
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                //Display Rooms 
                HttpClient client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/room").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }
}
