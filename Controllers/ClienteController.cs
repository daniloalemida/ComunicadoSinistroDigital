using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComunicadoSinistroDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _cli;
        private readonly ICriptografarServico _cri;

        public ClienteController(IClienteRepositorio cli, ICriptografarServico cri)
        {
            _cli = cli;
            _cri = cri;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _cli.GetAll();
            return Ok(usuarios);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _cli.GetById(id));
        }

        [HttpGet, Route("buscarPorCpf/{CPF}")]
        public async Task<IActionResult> GetByCPF(string CPF)
        {
            return Ok(await _cli.GetByCPF(CPF));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var user = await _cli.GetByCPF(cliente.CPF);
            if (user == null)
            {
                if (_cli.CPFValid(cliente.CPF))
                {
                    byte[] passwordHash, passwordSalt;
                    _cri.CreatePasswordHash(cliente.Senha, out passwordHash, out passwordSalt);
                    
                    var clienteCad = new Cliente
                    {
                        Login = cliente.CPF,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Nome = cliente.Nome,
                        CPF = cliente.CPF,
                        Data_nasc = cliente.Data_nasc,
                        Email = cliente.Email,
                        Celular = cliente.Celular
                    };
                    return Ok(await _cli.Create(clienteCad));
                }
                else
                {
                    return Ok("CPF invalido!");
                }

            }
            return Ok("Usuario já existe!");
        }

        [HttpDelete("{CPF}")]
        public async Task<ActionResult<bool>> Delete(string cpf)
        {
            var idUser = _cli.GetByCPF(cpf).Id;
            return await _cli.Delete(idUser);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(Cliente cliente)
        {
            return await _cli.Update(cliente);
        }        
    }
}