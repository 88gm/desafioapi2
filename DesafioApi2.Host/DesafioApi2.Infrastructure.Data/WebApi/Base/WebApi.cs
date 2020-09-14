using DesafioApi2.Infrastructure.Data.WebApi.Base;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System;

namespace DesafioApi2.Infrastructure.Data.WebApi
{
    public class WebApi
    {
        protected ApiConfig _apiConfig;

        public WebApi(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }

        protected Task<HttpClient> MakeHttpClient()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            var client = new HttpClient(httpClientHandler);

            return Task.FromResult(client);
        }

        protected async Task<TResult> GetAsync<TResult>(string request)
        {
            var client = await MakeHttpClient();
            var response = await client.GetAsync($"{_apiConfig.DesafioApi1}/{request}");

            return await ResultAsync(response, async () =>
            {
                var resp = await client.GetAsync($"{_apiConfig.DesafioApi1}/{request}");
                return await ResultAsync<TResult>(resp);
            });
        }

        protected async Task<TResult> ResultAsync<TResult>(HttpResponseMessage response, Func<Task<TResult>> func = null)
        {
            if (!response.IsSuccessStatusCode)
            {
                var responseErro = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException("Result Error", new Exception(responseErro));
            }

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(result);
        }

        protected async Task ResultAsync(HttpResponseMessage response, Func<Task> func = null)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && func != null)
                {
                    await func();
                }
                else
                {
                    var responseErro = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException("Result Error", new Exception(responseErro));
                }
            }
        }
    }
}
