using System.Threading.Tasks;
using ComunicadoSinistroDigital.Domain.Entities.Veiculo;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class VeiculoRepositorio : EntityRepositorio<Veiculo>, IVeiculoRepositorio
    {
        public VeiculoRepositorio(EntityContext context) : base(context)
        {
        }

        public async Task<Veiculo> GetByPlaca(string placa)
        {
            return await _context.Set<Veiculo>().FirstOrDefaultAsync(e => e.Placa == placa);
        }
    }
}