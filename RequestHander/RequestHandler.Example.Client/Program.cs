using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler.Example.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new ExampleService.TimeServiceClient())
            {
                var response = service.GetTheTime(new ExampleService.GetTheTimeRequest());
                Console.WriteLine(response.Time);
            }
            Console.ReadLine();
        }
    }
}
