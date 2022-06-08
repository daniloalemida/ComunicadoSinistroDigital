using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class CondutorRepositorio : EntityRepositorio<Condutor>, ICondutorRepositorio
    {
        public CondutorRepositorio(EntityContext context) : base(context)
        {
            
        }

        public async Task<List<Condutor>> GetByContrato(int codcontrato)
        {
            var condutores = await _context.Set<Condutor>().ToListAsync();

            return  condutores.FindAll(e => e.CodContrato == codcontrato);

        }
    }
}