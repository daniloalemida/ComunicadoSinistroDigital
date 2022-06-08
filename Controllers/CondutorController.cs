using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicadoSinistroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CondutorController : ControllerBase
    {
        private readonly ICondutorRepositorio _condutor;    

        public CondutorController(ICondutorRepositorio condutor)
        {
            _condutor = condutor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _condutor.GetAll();
            return Ok(usuarios);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _condutor.GetById(id));
        }

        [HttpGet, Route("buscarPorCodContrato/{codContrato}")]
        public async Task<IActionResult> GetByCodContrato(int codContrato)
        {
            return Ok(await _condutor.GetByContrato(codContrato));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Condutor condutor)
        {
            var contutorCad = new Condutor
            {
                CodContrato = condutor.CodContrato,
                Nome = condutor.Nome,
                CPF = condutor.CPF,
                Data_nasc = condutor.Data_nasc,
                Celular = condutor.Celular,
                Email = condutor.Email
            };
            return Ok(await _condutor.Create(contutorCad));        
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {            
            return await _condutor.Delete(id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(Condutor condutor)
        {
            return await _condutor.Update(condutor);
        }
    }
}
