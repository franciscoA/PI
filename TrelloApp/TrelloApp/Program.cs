using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGarten2;
using TrelloApp.Controllers;

namespace TrelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HttpHost("http://localhost:8080");
            host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(typeof(Controller)));
            host.Open();
            Console.WriteLine("Server is running, press any key to continue...");
            Console.ReadKey();
            host.Close();
        }
    }
}
