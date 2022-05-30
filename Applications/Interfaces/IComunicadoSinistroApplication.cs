
using ComunicadoSinistroDigital.Applications.Models;
using ComunicadoSinistroDigital.Applications.Result;

namespace ComunicadoSinistroDigital.Applications.Interfaces
{
    public interface IComunicadoSinistroApplication
    {
        Result<ComunicadoSinistroRetornoModel> CadastrarSinistro(ComunicadoDeSinistroModel comunicado);
    }
}
