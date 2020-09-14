using DesafioApi2.Domain.Juros;
using DesafioApi2.Domain.WebApi;
using System;
using System.Threading.Tasks;

namespace DesafioApi2.Domain.Services
{
    public class JurosService : IJurosService
    {
        IDesafioApi1Repository _desafioApi1Repository;
        public JurosService(IDesafioApi1Repository desafioApi1Repository)
        {
            _desafioApi1Repository = desafioApi1Repository ?? throw new ArgumentNullException();
        }

        public async Task<decimal> CalculaJuros(decimal vlInicial, int tempo)
        {
            try
            {
                var juros = await _desafioApi1Repository.GetTaxaJuros();
                var res = Math.Truncate(vlInicial * (decimal)Math.Pow(1 + juros.Taxa, tempo));
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
