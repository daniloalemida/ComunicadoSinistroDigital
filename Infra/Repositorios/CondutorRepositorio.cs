using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class CondutorRepositorio : EntityRepositorio<Condutor>, ICondutorRepositorio
    {
        public CondutorRepositorio(EntityContext context) : base(context)
        {
            
        }

        public List<Condutor> GetByContrato(int codcontrato)
        {
            var condutores = _context.Set<Condutor>().ToListAsync();

            List<Condutor> retorno = condutores.Result.FindAll(e => e.CodContrato == codcontrato);

            return retorno;
        }
    }
}