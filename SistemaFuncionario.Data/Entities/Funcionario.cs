using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFuncionario.Data.Entities
{
    public class Funcionario
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Funcionario()
        {
            //vazio
        }

        public Funcionario(Guid idFuncionario)
        {
            IdFuncionario = idFuncionario;
        }

        public Funcionario(string nome, string cpf, string matricula, DateTime dataAdmissao)
        {
            Nome = nome;
            Cpf = cpf;
            Matricula = matricula;
            DataAdmissao = dataAdmissao;
        }

        public Funcionario(Guid idFuncionario, string nome, string cpf, string matricula, DateTime dataAdmissao)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            Cpf = cpf;
            Matricula = matricula;
            DataAdmissao = dataAdmissao;
        }
    }
}
