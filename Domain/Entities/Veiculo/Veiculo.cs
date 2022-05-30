using System;

namespace ComunicadoSinistroDigital.Domain.Entities.Veiculo
{
    public class Veiculo : Entity
    {
        public string Placa { get; set; }
        public double ValorDiaria { get; set; }
        public string Marca {get; set;}
        public string Modelo {get;set;}
        public int Ano { get; set; }
        public string Categoria { get; set; }
        public bool CarroDisponivel { get; set; }
        public int IdAgencia { get; set; }
    }
}