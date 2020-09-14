using System.Threading.Tasks;

namespace DesafioApi2.Domain.Juros
{
    public interface IJurosService
    {
        Task<decimal> CalculaJuros(decimal vlInicial, int tempo);
    }
}
