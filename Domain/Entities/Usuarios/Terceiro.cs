﻿
namespace ComunicadoSinistroDigital.Domain.Entities.Usuarios
{
    public class Terceiro : Entity
    {
        public int CodSinistro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
