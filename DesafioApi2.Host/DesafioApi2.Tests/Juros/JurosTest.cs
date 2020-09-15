using DesafioApi2.Host;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace DesafioApi2.Tests.Juros
{
    public class JurosTest
    {

        private readonly HttpClient _httpClient;

        public JurosTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Fact]
        public async void CalculaJuros()
        {
            var res = await _httpClient.GetAsync("api/juros/calculajuros?vlInicial=100&tempo=5");
            Assert.Equal(System.Net.HttpStatusCode.OK, res.StatusCode);
        }
    }
}
