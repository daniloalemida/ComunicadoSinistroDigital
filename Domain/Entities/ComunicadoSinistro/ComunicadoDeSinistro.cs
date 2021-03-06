using System;

namespace ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro
{
    public class ComunicadoDeSinistro : Entity
    {
        public int CodContrato { get; set; }
        public int CodVeiculo { get; set; }
        public int CodCliente { get; set; }
        public int CodCondutorResponsavel { get; set; }
        public DateTime DataSinistro { get; set; }
        public string DescricaoSinistro { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool TerceiroEnvolvido { get; set; }
        public bool TerceiroIdentificado { get; set; }
        public int? CodTerceiro { get; set; }
        public bool TerceiroResponsavel { get; set; }
        public bool AutorizoSeguro { get; set; }
        public bool TemRoboque { get; set; }
        public int? CodReboque { get; set; }
        public bool BOEnviado { get; set; }
    }
}
