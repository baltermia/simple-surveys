using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSurveys.Client.Utils
{
    public static class HttpClientExtensions
    {
        private static JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        public static async Task<T> GetBasicAsync<T>(this HttpClient client, string url)
        {
            HttpResponseMessage result = await client.GetAsync(url);

            string resultJson = await result.Content.ReadAsStringAsync();

            T value = JsonConvert.DeserializeObject<T>(resultJson, settings);

            return value;
        }

        public static async Task<T> PostBasicAsync<T>(this HttpClient client, string url, T value)
        {
            string json = JsonConvert.SerializeObject(value, settings);

            StringContent content = GetContent(json);

            HttpResponseMessage result = await client.PostAsync(url, content);

            string resultJson = await result.Content.ReadAsStringAsync();

            T created = JsonConvert.DeserializeObject<T>(resultJson, settings);

            return created;
        }

        public static async Task<T> PutBasicAsync<T>(this HttpClient client, string url, T value)
        {
            string json = JsonConvert.SerializeObject(value, settings);

            StringContent content = GetContent(json);

            HttpResponseMessage result = await client.PutAsync(url, content);

            string resultJson = await result.Content.ReadAsStringAsync();

            T updated = JsonConvert.DeserializeObject<T>(resultJson, settings);

            return updated;
        }

        private static StringContent GetContent(string json) => new StringContent(json, Encoding.UTF8, "application/json");
    }
}
