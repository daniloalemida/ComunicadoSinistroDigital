
using ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class ReboqueRepositorio : EntityRepositorio<Reboque>, IReboqueRepositorio
    {
        public ReboqueRepositorio(EntityContext context) : base(context)
        {
        }        
    }
}