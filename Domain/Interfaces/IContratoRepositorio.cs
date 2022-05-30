using ComunicadoSinistroDigital.Domain.Entities.Locacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface IContratoRepositorio : IEntityRepositorio<Contrato>
    {
        Task<Contrato> GetByPlaca(string placa);
        List<Contrato> GetByCliente(int cliente);

    }
}