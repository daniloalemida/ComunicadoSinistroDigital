using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using System.Threading.Tasks;

namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface IClienteRepositorio : IEntityRepositorio<Cliente>
    {
        Task<Cliente> GetByCPF(string CPF);

        bool CPFValid(string CPF);
         
    }
}