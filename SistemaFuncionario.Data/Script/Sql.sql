create table Funcionario (
	IdFuncionario uniqueidentifier not null,
	Nome nvarchar(200) not null,
	Cpf nvarchar(11) not null,
	Matricula nvarchar(10) not null,
	DataAdmissao date not null,
	DataCadastro datetime not null,
	DataAlteracao datetime not null,
	primary key(IdFuncionario)
)
GO

create procedure Sp_Insert_Funcionario
	@Nome nvarchar(200),
	@Cpf nvarchar(11),
	@Matricula nvarchar(10),
	@DataAdmissao date
As
Begin
	Begin Transaction
		insert into Funcionario (IdFuncionario,Nome,Cpf,Matricula,DataAdmissao,DataCadastro,DataAlteracao)
		                 values (newid(),@Nome,@Cpf,@Matricula,@DataAdmissao,getdate(),getdate())
	Commit
End
GO

create procedure Sp_Update_Funcionario
    @IdFuncionario uniqueidentifier,
	@Nome nvarchar(200),
	@Cpf nvarchar(11),
	@Matricula nvarchar(10),
	@DataAdmissao date
As
Begin
	Begin Transaction
		update Funcionario set
		       Nome = @Nome
		      ,Cpf = @Cpf
		      ,Matricula = @Matricula
			  ,DataAdmissao = @DataAdmissao
			  ,DataAlteracao = getdate()
		 where IdFuncionario = @IdFuncionario
	Commit
End
GO

create procedure Sp_Delete_Funcionario
    @IdFuncionario uniqueidentifier
As
Begin
	Begin Transaction
		delete from Funcionario 
		 where IdFuncionario = @IdFuncionario
	Commit
End
GO

create procedure Sp_SelectAll_Funcionario
As
Begin
	select IdFuncionario,Nome,Cpf,Matricula,DataAdmissao,DataCadastro,DataAlteracao
	  from Funcionario
End
GO

create procedure Sp_SelectId_Funcionario
	@IdFuncionario uniqueidentifier
As
Begin
	select IdFuncionario,Nome,Cpf,Matricula,DataAdmissao,DataCadastro,DataAlteracao
	  from Funcionario
	 where IdFuncionario = @IdFuncionario
End
GO