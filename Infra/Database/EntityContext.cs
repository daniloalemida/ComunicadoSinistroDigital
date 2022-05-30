using ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistroDigital.Domain.Entities.Locacao;
using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Entities.Veiculo;
using Microsoft.EntityFrameworkCore;

namespace ComunicadoSinistroDigital.Infra.Database
{
    public class EntityContext : DbContext
    {      
        public EntityContext (DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fazer join maroto no banco agencia/veiculo            
        }

        public DbSet<ComunicadoDeSinistro> ComunicadoDeSinistro { get; set; }
        public DbSet<Reboque> Reboque { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Condutor> Condutor { get; set; }
        public DbSet<Terceiro> Terceiro { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        
        
    }
}