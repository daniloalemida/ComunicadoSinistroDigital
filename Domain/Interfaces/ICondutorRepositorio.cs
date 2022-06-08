using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using System.Collections.Generic;

namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface ICondutorRepositorio : IEntityRepositorio<Condutor>
    {
        System.Threading.Tasks.Task<List<Condutor>> GetByContrato(int codcontrato);

    }
}