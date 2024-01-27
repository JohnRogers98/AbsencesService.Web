using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AbsenceService.Client.Helpers
{
    public static class HttpHelper
    {
        public static async Task<string> GetAsync(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            var responseString =  await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public static async Task<HttpStatusCode> PostAsync<T>(string url, T data)
        {
            var serializedData = JsonConvert.SerializeObject(data);

            var requestContent = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, requestContent);

            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> DeleteAsync(string url)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.DeleteAsync(url);

            return response.StatusCode;
        }

        public static async Task<HttpStatusCode> PutAsync<T>(string url, T data)
        {
            var serializedData = JsonConvert.SerializeObject(data);

            var requestContent = new StringContent(serializedData, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PutAsync(url, requestContent);

            return response.StatusCode;
        }
    }
}
