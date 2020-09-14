using System.Threading.Tasks;

namespace DesafioApi2.Domain.WebApi
{
    public interface IDesafioApi1Repository
    {
        Task<Juros.Juros> GetTaxaJuros();
    }
}
