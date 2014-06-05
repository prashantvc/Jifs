using System;
using System.Net.Http;
using System.Threading.Tasks;
using Jifs.Model;
using Newtonsoft.Json;

namespace Jifs
{
    public class JifContext : IDisposable
    {
        const string BaseUrl = "http://api.giphy.com/v1/gifs/";
        const string APIKey = "dc6zaTOxFJmzC";
        readonly HttpClient _httpClient;

        public JifContext()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<Rootobject> GetTrendingAsync()
        {
            string url = GetRequestUrl("trending?");
            return await GetResponseAsyc<Rootobject>(url);
        }

        public async Task<Rootobject> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            string url = GetRequestUrl("search?q=" + query);
            return await GetResponseAsyc<Rootobject>(url);
        }

        public async Task<Image> GetImageByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            string url = string.Format("{0}?api_key={1}", id, APIKey);
            return await GetResponseAsyc<Image>(url);
        }

        async Task<T> GetResponseAsyc<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

		//async Task<Task>

        static string GetRequestUrl(string urlPart)
        {
            return string.Format("{0}&api_key={1}", urlPart, APIKey);
        }

        public void Dispose()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
            }
        }
    }
}
