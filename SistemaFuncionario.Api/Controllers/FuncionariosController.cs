using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFuncionario.Api.Model;
using SistemaFuncionario.Data.Entities;
using SistemaFuncionario.Data.Repositories;

namespace SistemaFuncionario.Api.Controllers
{
    //Patros Rest (Post cadastro, Put edição, Delete exclusãoe e Get consulta)

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FuncionariosPostModel model)
        {
            //cadastro de funcionario
            try
            {
                Funcionario funcionario = new Funcionario(model.Nome, model.Cpf,model.Matricula, model.DataAdmissao);
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Insert(funcionario);
                return StatusCode(201, new { mensage = $"Funcionario {funcionario.Nome} cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensage = $"Falha: {e.Message}" });
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionariosPutModel model)
        {
            //edicao de funcionario
            try
            {
                Funcionario funcionario = new Funcionario(model.IdFuncionario, model.Nome, model.Cpf, model.Matricula, model.DataAdmissao);
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Update(funcionario);
                return StatusCode(200, new { mensage = $"Funcionario {funcionario.Nome} atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensage = $"Falha: {e.Message}" });
            }
        }

        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(Guid idFuncionario)
        {
            //exclusao de funcionario
            try
            {
                Funcionario funcionario = new Funcionario();
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                funcionario = funcionarioRepository.GetById(idFuncionario);
                if (funcionario != null)
                {
                    funcionarioRepository.Delete(funcionario.IdFuncionario);
                    return StatusCode(200, new { mensage = $"Funcionario {funcionario.Nome} excluido com sucesso." });
                }

                return StatusCode(204, new { mensage = $"Funcionario não encontrado" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensage = $"Falha: {e.Message}" });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(List<FuncionariosGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                List<FuncionariosGetModel> funcionariosGetModel = new List<FuncionariosGetModel>();
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                foreach (var item in funcionarioRepository.GetAll())
                {
                    FuncionariosGetModel model = new FuncionariosGetModel();
                    model.IdFuncionario = item.IdFuncionario;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Matricula = item.Matricula;
                    model.DataAdmissao = item.DataAdmissao;
                    model.DataCadastro = item.DataCadastro;
                    model.DataAlteracao = item.DataAlteracao;
                    funcionariosGetModel.Add(model);
                }

                return StatusCode(200, funcionariosGetModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensage = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idFuncionario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FuncionariosGetModel))]
        public IActionResult GetById(Guid idFuncionario)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
                funcionario = funcionarioRepository.GetById(idFuncionario);
                if (funcionario != null)
                {
                    FuncionariosGetModel model = new FuncionariosGetModel();
                    model.IdFuncionario = funcionario.IdFuncionario;
                    model.Nome = funcionario.Nome;
                    model.Cpf = funcionario.Cpf;
                    model.Matricula = funcionario.Matricula;
                    model.DataAdmissao = funcionario.DataAdmissao;
                    model.DataCadastro = funcionario.DataCadastro;
                    model.DataAlteracao = funcionario.DataAlteracao;
                    return StatusCode(200, model);
                }

                return StatusCode(204, new { mensage = $"Funcionario não encontrado" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensage = $"Falha: {e.Message}" });
            }
        }
    }
}
