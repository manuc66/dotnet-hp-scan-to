using System;
using System.IO;
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
            HttpClient httpClient = new HttpClient();
            string addr = $"{_baseUrl}/WalkupScan/WalkupScanDestinations";
            HttpResponseMessage response = await httpClient.GetAsync(addr);

            using (Stream inStream = await response.Content.ReadAsStreamAsync())
            {
                return WalkupScanDestinations.CreateFromStream(inStream);
            }
        }

        public async Task<(EventTable, EntityTagHeaderValue)> GetEvents()
        {
            HttpClient httpClient = new HttpClient();
            string addr = $"{_baseUrl}/EventMgmt/EventTable";
            HttpResponseMessage response = await httpClient.GetAsync(addr);

            using (Stream inStream = await response.Content.ReadAsStreamAsync())
            {
                return (EventTable.CreateFromStream(inStream), response.Headers.ETag);
            }
        }

        public async Task<(EventTable, EntityTagHeaderValue)> WaitEvents(string etag, int timeout)
        {
            HttpClient httpClient = new HttpClient();
            string addr = $"{_baseUrl}/EventMgmt/EventTable?timeout=" + timeout;
            HttpResponseMessage response = await httpClient.GetAsync(addr);

            using (Stream inStream = await response.Content.ReadAsStreamAsync())
            {
                return (EventTable.CreateFromStream(inStream), response.Headers.ETag);
            }
        }

        public async Task<Uri> PostWalkupScanDestinations(WalkupScanDestinationPost destination)
        {
            HttpClient httpClient = new HttpClient();
            string addr = $"{_baseUrl}/WalkupScan/WalkupScanDestinations";
            HttpResponseMessage response = await httpClient.PostAsync(addr,
                new StringContent(destination.SerializeToXml(), Encoding.UTF8, "text/xml"));

            return response.Headers.Location;
        }
    }
}