using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPScanTo.Generated;
using Zeroconf;

namespace HPScanTo
{
    internal class Program
    {
        private const string DEVICE_NAME = "Officejet 6500 E710n-z";

        internal static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task ret;
            var ipAddress = await GetDeviceIPAddress();

            Console.WriteLine(ipAddress);

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
            var destinations = await hpApi.GetWalkupScanDestinations();

            var destination = destinations.WalkupScanDestination.Find(dest => Environment.MachineName == dest.Hostname);
            if (destination == null)
            {
                await hpApi.PostWalkupScanDestinations(WalkupScanDestinationPost.CreateFrom(Environment.MachineName, Environment.MachineName));
            }
            else
            {
                Console.WriteLine($"Reusing {destination.Name} - {destination.Hostname}");
            }
        }
    }
}