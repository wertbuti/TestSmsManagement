using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestSmsManagement
{
    public class ApiCaller
    {
        private readonly string _url;

        public ApiCaller(string url)
        {
            _url = url;
        }

        public async Task PostAsync(string requestUrl, object obj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            var jSonData = JsonConvert.SerializeObject(obj);
            var content = new StringContent(jSonData, Encoding.UTF8, "application/json");

            client.PostAsync(requestUrl, content);
        }
    }
}