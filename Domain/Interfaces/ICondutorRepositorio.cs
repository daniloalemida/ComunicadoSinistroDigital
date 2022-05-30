using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using System.Collections.Generic;

namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface ICondutorRepositorio : IEntityRepositorio<Condutor>
    {
        List<Condutor> GetByContrato(int codcontrato);

    }
}