using ComunicadoSinistroDigital.Domain.Entities.Locacao;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class AgenciaRepositorio : EntityRepositorio<Agencia>, IAgenciaRepositorio
    {
        public AgenciaRepositorio(EntityContext context) : base(context)
        {
        }
        
    }
}