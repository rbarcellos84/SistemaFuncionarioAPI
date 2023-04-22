using System.ComponentModel.DataAnnotations;

namespace SistemaFuncionario.Api.Model
{
    public class FuncionariosPutModel
    {
        ///<summary>
        ///PUT /api/Funcionarios
        ///<summary>
        [Required(ErrorMessage = "Por favor, informe id do funcionário.")]
        public Guid IdFuncionario { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 digitos numéricos")]
        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        public string Cpf { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(10, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a matricula do funcionário.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de adminissao do funcionário.")]
        public DateTime DataAdmissao { get; set; }
    }
}
