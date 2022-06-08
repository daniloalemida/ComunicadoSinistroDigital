using ComunicadoSinistroDigital.Applications.Interfaces;
using ComunicadoSinistroDigital.Applications.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunicadoSinistroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _loginApplication;

        public LoginController(ILoginApplication loginApplication)
        {
            _loginApplication = loginApplication;

        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginRetornoModel), StatusCodes.Status200OK)]
        public IActionResult Login(string login, string senha)
        {
            try
            {
                var retorno = _loginApplication.Login(login, senha);

                if (retorno.Result.Success)
                {
                    return Ok(retorno.Result);
                }
                return BadRequest(retorno.Result.Notifications);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
