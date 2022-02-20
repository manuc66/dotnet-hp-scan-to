using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            string ipAddress = await GetDeviceIPAddress();

            Console.WriteLine(ipAddress);

            await Register(ipAddress);

        }


        public static async Task<string> GetDeviceIPAddress()
        {
            ILookup<string, string> domains = await ZeroconfResolver.BrowseDomainsAsync();
            IReadOnlyList<IZeroconfHost> responses = await ZeroconfResolver.ResolveAsync(domains.Select(g => g.Key));
            foreach (IZeroconfHost resp in responses)
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
            HPApi hpApi = new HPApi(ipAddress);
            WalkupScanDestinations destinations = await hpApi.GetWalkupScanDestinations();

            WalkupScanDestination destination = destinations.WalkupScanDestination.Find(dest => Environment.MachineName == dest.Hostname);
            if (destination == null)
            {
                await hpApi.PostWalkupScanDestinations(WalkupScanDestinationPost.CreateFrom(Environment.MachineName, Environment.MachineName));
            }
            else
            {
                Console.WriteLine($"Reusing {destination.Name} - {destination.Hostname}");
            }

            (EventTable eventTable, EntityTagHeaderValue etag) = await hpApi.GetEvents();

            await hpApi.WaitEvents(etag.Tag, 1200);
        }
    }
}