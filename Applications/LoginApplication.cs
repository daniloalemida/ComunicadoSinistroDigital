using ComunicadoSinistroDigital.Applications.Interfaces;
using ComunicadoSinistroDigital.Applications.Models;
using ComunicadoSinistroDigital.Applications.Result;
using ComunicadoSinistroDigital.Domain.Entities.ComunicadoSinistro;
using ComunicadoSinistroDigital.Domain.Entities.Usuarios;
using ComunicadoSinistroDigital.Domain.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComunicadoSinistroDigital.Applications
{
    public class LoginApplication : ILoginApplication
    {
        private readonly IClienteRepositorio _cliente;
        private readonly ICriptografarServico _criptografia;
        private readonly IContratoRepositorio _contrato;
        private readonly IComunicadoSinistroRepositorio _sinistro;
        private readonly ICondutorRepositorio _condutor;
        private readonly IVeiculoRepositorio _veiculo;
        private readonly ITerceiroRepositorio _terceiro;
        private readonly IReboqueRepositorio _reboque;

        public LoginApplication(IClienteRepositorio cli, ICriptografarServico cri, IContratoRepositorio cont, 
            IComunicadoSinistroRepositorio sinistro, ICondutorRepositorio condutor, IVeiculoRepositorio veiculo,
            ITerceiroRepositorio terceiro, IReboqueRepositorio reboque)
        {
            _cliente = cli;
            _criptografia = cri;
            _contrato = cont;
            _sinistro = sinistro;
            _condutor = condutor;
            _veiculo = veiculo;
            _terceiro = terceiro;
            _reboque = reboque;
        }

        public async Task<Result<LoginRetornoModel>> Login(string login, string senha)
        {

            var cliente = await _cliente.GetByCPF(login);

            if (cliente.Nome != null)
            {
                if(_criptografia.VerifyPasswordHash(senha, cliente.PasswordHash, cliente.PasswordSalt))
                {
                    var sinistros = _sinistro.GetByCliente(cliente.Id);

                    List<SinistroRetornoModel> listaHistoricoSinistro = new List<SinistroRetornoModel>();
                    List<ContratoRetornoModel> listaDadosContratosAtivos = new List<ContratoRetornoModel>();

                    if (sinistros.Count > 0)
                    {
                        foreach (var sinistro in sinistros)
                        {
                            //buscar o condutor
                            var condutor = _condutor.GetById(sinistro.CodCondutorResponsavel).Result;

                            //buscar o veiculo
                            var veiculo = _veiculo.GetById(sinistro.CodVeiculo).Result;

                            // if terceriro identificado buscar terceiro
                            Terceiro terceiro = new Terceiro();
                            if (sinistro.TerceiroIdentificado)
                            {
                                int codTerceiro = sinistro.CodTerceiro.GetValueOrDefault();  
                                terceiro = _terceiro.GetById(codTerceiro).Result;
                            }

                            // if tem reboque buscar reboque
                            Reboque reboque = new Reboque();
                            if (sinistro.TemRoboque)
                            {
                                int codReboque =  sinistro.CodReboque.GetValueOrDefault();
                                reboque = _reboque.GetById(codReboque).Result;
                            }

                            listaHistoricoSinistro.Add(new SinistroRetornoModel()
                            {
                                CodSinistro = sinistro.Id,
                                CodContrato = sinistro.CodContrato,
                                Condutor = condutor,
                                Carro = veiculo,
                                Cliente = cliente,
                                DataSinistro = sinistro.DataSinistro,
                                DescricaoOcorrido = sinistro.DescricaoSinistro,
                                TerceiroEnvolvido = sinistro.TerceiroEnvolvido,
                                TerceiroResponsavel = sinistro.TerceiroResponsavel,
                                AutorizoSeguro = sinistro.AutorizoSeguro,
                                TerceiroIdentificado = sinistro.TerceiroIdentificado,
                                Terceiro = terceiro,
                                CEP = sinistro.CEP,
                                Logradouro = sinistro.Logradouro,
                                Numero = sinistro.Numero,
                                Complemento = sinistro.Complemento,
                                Bairro = sinistro.Bairro,
                                Cidade = sinistro.Cidade,
                                UF = sinistro.UF,
                                BOEnviado = sinistro.BOEnviado,
                                TemReboque = sinistro.TemRoboque,
                                Reboque = reboque
                            });
                        }
                    }

                    var contratos = _contrato.GetByCliente(cliente.Id);

                    if (contratos.Count > 0)
                    {
                        foreach (var contrato in contratos)
                        {
                            var veiculo = _veiculo.GetById(contrato.CodVeiculo).Result;

                            //List<Condutor> 
                            var condutores = _condutor.GetByContrato(contrato.Id);

                            listaDadosContratosAtivos.Add(new ContratoRetornoModel() {
                                CodContrato = contrato.Id, 
                                Cliente = cliente,
                                VeiculoAlugado = veiculo,
                                Condutores = condutores.Result
                            });
                        }
                    }

                    return Result<LoginRetornoModel>.Ok(new LoginRetornoModel()
                    {
                        HistoricoSinistro = listaHistoricoSinistro,
                        DadosContratosAtivos = listaDadosContratosAtivos
                    });
                }
                else
                {
                    return Result<LoginRetornoModel>.Error(new List<Notification>() { new Notification(nameof(LoginRetornoModel), "Senha não confere") });
                }
            }
            else
            {
                return Result<LoginRetornoModel>.Error(new List<Notification>() { new Notification(nameof(LoginRetornoModel), "Cliente não existe") });
            }



            throw new System.NotImplementedException();
        }

        public bool RecuperarSeha(string login, string senha)
        {
            throw new System.NotImplementedException();
        }
    }
}
