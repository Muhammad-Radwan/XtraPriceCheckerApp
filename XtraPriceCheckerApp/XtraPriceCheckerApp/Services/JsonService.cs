using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XtraPriceCheckerApp.Models;
namespace FakeJSON.Services
{
    public class JsonService
    {
        public async Task<List<TBL007>> GetPrice(string ip, string port, string Barcode)
        {
            string url = $"http://{ip}:{port}/api/Prices?Barcode={Barcode}";
            HttpClient _client = new HttpClient();
            var clientStr = await _client.GetStringAsync(url);
            List<TBL007> data = JsonConvert.DeserializeObject<List<TBL007>>(clientStr);
            return data;
        }
    }
}
