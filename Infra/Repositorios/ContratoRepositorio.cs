using System.Collections.Generic;
using System.Threading.Tasks;
using ComunicadoSinistroDigital.Domain.Entities.Locacao;
using ComunicadoSinistroDigital.Domain.Interfaces;
using ComunicadoSinistroDigital.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace ComunicadoSinistroDigital.Infra.Repositorios
{
    public class ContratoRepositorio : EntityRepositorio<Contrato>, IContratoRepositorio
    {
        public ContratoRepositorio(EntityContext context) : base(context)
        {
        }

        public List<Contrato> GetByCliente(int cliente)
        {
            var contratos =  _context.Set<Contrato>().ToListAsync();

            List<Contrato> retorno = contratos.Result.FindAll(e => e.CodCliente == cliente);

            return retorno;
        }                

        public async Task<Contrato> GetByPlaca(string placa)
        {
            return await _context.Set<Contrato>().FirstOrDefaultAsync(e => e. Placa == placa);
        }
    }
}