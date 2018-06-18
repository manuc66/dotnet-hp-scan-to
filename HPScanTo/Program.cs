using System;
using System.Linq;
using System.Threading.Tasks;
using Zeroconf;

namespace HPScanTo
{
    class Program
    {
        private static string DEVICE_NAME = "Officejet 6500 E710n-z";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task t = MainAsync(args);
            t.Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var ipAddress = await GetDeviceIPAddress();
            await Register(ipAddress);
        }


        public static async Task<string> GetDeviceIPAddress()
        {
            var domains = await ZeroconfResolver.BrowseDomainsAsync();
            var responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key));
            foreach (var resp in responses)
            {
                if (resp.DisplayName.StartsWith(DEVICE_NAME))
                {
                    return resp.IPAddress;
                }
            }

            throw new Exception($"No ${DEVICE_NAME} found!");
        }

        public static async Task Register(string ipAddress)
        {
            var hpApi = new HPApi(ipAddress);
            await hpApi.GetWalkupScanDestinations();
        }
    }
}