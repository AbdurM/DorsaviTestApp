using DorsaviTestApp.Gateway.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DorsaviTestApp.Gateway.Implementations
{
    public abstract class GatewayBase<T>
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetJsonStream(string url)
        {
            if (string.IsNullOrEmpty(url))
                return default;

            string content = string.Empty;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                content = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                //Would use logging to relevant platform(ex raygun) in prod
                Debug.WriteLine(ex.Message);
            }
            return content;
        }
    }
}
