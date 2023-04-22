using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFuncionario.Data.Entities;
using SistemaFuncionario.Data.Configurations;
using Dapper;
using System.Data;

namespace SistemaFuncionario.Data.Repositories
{
    public class FuncionarioRepository
    {
        public void Insert(Funcionario funcionario)
        {
            //conectar com o banco
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executa comando no sql
                connection.Execute("Sp_Insert_Funcionario", new
                {
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Funcionario funcionario)
        {
            //conectar com o banco
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executa comando no sql
                connection.Execute("Sp_Update_Funcionario", new
                {
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao,
                    @IdFuncionario = funcionario.IdFuncionario
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Guid idFuncionario)
        {
            //conectar com o banco
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executa comando no sql
                connection.Execute("Sp_Delete_Funcionario", new
                {
                    @IdFuncionario = idFuncionario
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public Funcionario? GetById(Guid idFuncionario)
        {
            //conectar com o banco
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executa comando no sql
                return connection.Query<Funcionario>("Sp_SelectId_Funcionario", new 
                { 
                    @IdFuncionario = idFuncionario 
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<Funcionario> GetAll()
        {
            //conectar com o banco
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                //executa comando no sql
                return connection.Query<Funcionario>("Sp_SelectAll_Funcionario", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
