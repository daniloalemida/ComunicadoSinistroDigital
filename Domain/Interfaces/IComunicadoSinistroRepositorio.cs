using ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro;
using System.Collections.Generic;

namespace ComunicadoSinistroDigital.Domain.Interfaces
{
    public interface IComunicadoSinistroRepositorio : IEntityRepositorio<ComunicadoDeSinistro>
    {
        List<ComunicadoDeSinistro> GetByCliente(int cliente);

    }
}