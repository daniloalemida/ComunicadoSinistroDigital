
using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;


namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class TerceiroRepositorio : EntityRepositorio<Terceiro>, ITerceiroRepositorio
    {
        public TerceiroRepositorio(EntityContext context) : base(context)
        {
        }
        
    }
}