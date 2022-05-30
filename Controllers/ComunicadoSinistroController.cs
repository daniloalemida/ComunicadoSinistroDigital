using System.Threading.Tasks;
using ComunicadoSinistroDigital.Applications.Interfaces;
using ComunicadoSinistroDigital.Applications.Models;
using ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistroDigital.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunicadoSinistroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunicadoSinistroController : ControllerBase    
    {
        private readonly IComunicadoSinistroApplication _comunicadoSinistro;
        private readonly IComunicadoSinistroRepositorio _rep;

        public ComunicadoSinistroController(IComunicadoSinistroApplication comunicadoSinistro, IComunicadoSinistroRepositorio rep)
        {
            _comunicadoSinistro = comunicadoSinistro;
            _rep = rep;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ComunicadoSinistroRetornoModel), StatusCodes.Status200OK)]
        public IActionResult Login(ComunicadoDeSinistroModel comunicado)
        {
            try
            {
                var retorno = _comunicadoSinistro.CadastrarSinistro(comunicado);

                if (retorno.Success)
                {
                    return Ok(retorno);
                }
                return BadRequest(retorno.Notifications);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rep.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rep.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ComunicadoDeSinistro contrato)
        {
            return Ok(await _rep.Update(contrato));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _rep.Delete(id));
        }

    }
}