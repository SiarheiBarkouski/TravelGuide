using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace TravelGuide.XamarinUI.WebApiClients
{
    public partial class WebApiClient : IDisposable
    {
        public string BaseUrl { get; }

        private HttpClient httpClient;

        public WebApiClient()
        {
            BaseUrl = @"http://192.168.100.6:49675";

            Initialize();
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        private T Get<T>(string url)
        {
            try
            {
                var result = httpClient.GetAsync(url).Result;
                CheckResponse(result);
                return DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        private TOut Post<TIn, TOut>(string url, TIn parameter)
        {
            var result = httpClient.PostAsync(url, CreateJsonContent(parameter)).Result;
            CheckResponse(result);

            return DeserializeObject<TOut>(result);
        }

        private void Post<T>(string url, T parameter)
        {
            var result = httpClient.PostAsync(url, CreateJsonContent(parameter)).Result;
            CheckResponse(result);
        }

        private void Initialize()
        {
            if (string.IsNullOrEmpty(BaseUrl))
            {
                string message = "Base address is null or empty.";
                throw new Exception(message);
            }

            httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = TimeSpan.FromSeconds(600);
        }

        private void CheckResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return;
            }

            throw new Exception($"Request to '{response.RequestMessage.RequestUri}' returns code: '{response.StatusCode}'.");
        }

        private StringContent CreateJsonContent(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        private T DeserializeObject<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}