
using ComunicadoSinistroDigital.Applications.Models;
using ComunicadoSinistroDigital.Applications.Result;

namespace ComunicadoSinistroDigital.Applications.Interfaces
{
    public interface ILoginApplication
    {
        System.Threading.Tasks.Task<Result<LoginRetornoModel>> Login(string login, string senha);

        bool RecuperarSeha(string login, string senha);
    }
}
