using System.Collections.Generic;

namespace ComunicadoSinistroDigital.Applications.Models
{
    public class LoginRetornoModel
    {
        public List<SinistroRetornoModel> HistoricoSinistro { get; set; }
        public List<ContratoRetornoModel> DadosContratosAtivos { get; set; }
    }
}
