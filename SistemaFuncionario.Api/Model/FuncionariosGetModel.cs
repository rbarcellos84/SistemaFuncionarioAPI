using System.ComponentModel.DataAnnotations;

namespace SistemaFuncionario.Api.Model
{
    public class FuncionariosGetModel
    {
        ///<summary>
        ///GET /api/Funcionarios
        ///<summary>
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
