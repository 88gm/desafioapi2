using DesafioApi2.Domain.Juros;
using DesafioApi2.Domain.WebApi;
using DesafioApi2.Infrastructure.Data.WebApi.Base;
using System.Threading.Tasks;

namespace DesafioApi2.Infrastructure.Data.WebApi
{
    public class DesafioApi1Repository : WebApi, IDesafioApi1Repository
    {
        public DesafioApi1Repository(ApiConfig apiConfig) : base(apiConfig)
        { }

        public Task<Juros> GetTaxaJuros()
            => GetAsync<Juros>("/api/juros/taxa");
    }
}
