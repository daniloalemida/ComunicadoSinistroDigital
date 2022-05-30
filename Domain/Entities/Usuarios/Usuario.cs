
namespace ComunicadoSinistroDigital.Domain.Entities.Usuarios
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        
        public string Senha { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}