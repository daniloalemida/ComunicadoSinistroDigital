using ComunicadoSinistroDigital.Domain.Entities.Veiculo;
using System.Threading.Tasks;


namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface IVeiculoRepositorio : IEntityRepositorio<Veiculo>
    {
        Task<Veiculo> GetByPlaca(string placa);
         
    }
}