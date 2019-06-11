using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HPScanTo.Generated;

namespace HPScanTo
{
    internal class HPApi
    {
        private readonly string _baseUrl;

        public HPApi(string ipAddress)
        {
            _baseUrl = $"http://{ipAddress}";
        }

        public async Task<WalkupScanDestinations> GetWalkupScanDestinations()
        {
            var httpClient = new HttpClient();
            var addr = $"{_baseUrl}/WalkupScan/WalkupScanDestinations";
            var response = await httpClient.GetAsync(addr);

            using (var inStream = await response.Content.ReadAsStreamAsync())
            {
                return WalkupScanDestinations.CreateFromStream(inStream);
            }
        }

        public async Task<(EventTable, EntityTagHeaderValue)> GetEvents()
        {
            var httpClient = new HttpClient();
            var addr = $"{_baseUrl}/EventMgmt/EventTable";
            var response = await httpClient.GetAsync(addr);

            using (var inStream = await response.Content.ReadAsStreamAsync())
            {
                return (EventTable.CreateFromStream(inStream), response.Headers.ETag);
            }
        }

        public async Task<(EventTable, EntityTagHeaderValue)> WaitEvents(string etag, int timeout)
        {
            var httpClient = new HttpClient();
            var addr = $"{_baseUrl}/EventMgmt/EventTable?timeout=" + timeout;
            var response = await httpClient.GetAsync(addr);

            using (var inStream = await response.Content.ReadAsStreamAsync())
            {
                return (EventTable.CreateFromStream(inStream), response.Headers.ETag);
            }
        }

        public async Task<Uri> PostWalkupScanDestinations(WalkupScanDestinationPost destination)
        {
            var httpClient = new HttpClient();
            var addr = $"{_baseUrl}/WalkupScan/WalkupScanDestinations";
            var response = await httpClient.PostAsync(addr,
                new StringContent(destination.SerializeToXml(), Encoding.UTF8, "text/xml"));

            return response.Headers.Location;
        }
    }
}