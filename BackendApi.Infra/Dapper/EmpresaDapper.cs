using BackendApi.Dominio.Entidade;
using BackendApi.Infra.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Infra.Dapper
{
    public class EmpresaDapper
    {
        string connectionString = "Data Source=VLNOTE32\\SQLEXPRESS;Initial Catalog=SistemaGerenciamentoManutencao;User Id=sa;Password=3fodux69;Integrated Security=False;Trusted_Connection=False;Encrypt=False";

        private readonly MeuContext _contexto;
        public EmpresaDapper(MeuContext dbContext)
        {
            _contexto = dbContext;
        }

        public void Criar(Guid idTenant)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                // Verifica se a tabela existe
                bool tabelaExiste = dbConnection.ExecuteScalar<bool>(
                "IF OBJECT_ID('Empresa', 'U') IS NOT NULL SELECT 1 ELSE SELECT 0");
                if (!tabelaExiste)
                {
                    // Cria a tabela
                    dbConnection.Execute(@"
                    CREATE TABLE Empresa
                    (
                        Id UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
                        Id_Tenant UNIQUEIDENTIFIER NOT NULL,
                        Referencia VARCHAR(50) NOT NULL,
                        Descricao VARCHAR(300) NOT NULL,
                        RazaoSocial VARCHAR(300) NOT NULL,
                        NomeFantasia VARCHAR(300) NOT NULL,
                        Cnpj VARCHAR(14),
                        DataCadastro DATETIME NOT NULL,
                        PessoaContato VARCHAR(300),
                        Email VARCHAR(300),
                        Telefone VARCHAR(50),
                        Endereco VARCHAR(300),
                        Numero VARCHAR(20),
                        Complemento VARCHAR(100),
                        Cep VARCHAR(8),
                        Cidade VARCHAR(100),
                        Estado CHAR(2),
                        Observacao VARCHAR(MAX),
                        Inativo BIT DEFAULT 0 NOT NULL
                    )");

                    // Cria a chave estrangeira
                    dbConnection.Execute(@"
                    ALTER TABLE Empresa ADD CONSTRAINT FK_Empresa_Tenant FOREIGN KEY (Id_Tenant) REFERENCES Tenant(Id)");

                    // Cria o índice único
                    dbConnection.Execute("CREATE UNIQUE INDEX IDX_Empresa_UQ ON Empresa (Id, Referencia)");
                }

                // Inserção de um registro na tabela Empresa
                var empresa = new Empresa
                {
                    Id_Tenant = idTenant,
                    Referencia = "EMP0001",
                    Descricao = "Okea empresa de tecnologia de Brusque",
                    RazaoSocial = "OKEA LTDA",
                    NomeFantasia = "OKEA impresa tecnologia LTDA",
                    Cnpj = "06955708000182",
                    DataCadastro = DateTime.Now,
                    PessoaContato = "Pessoa Contato Okea",
                    Email = "email@terra.com.br",
                    Telefone = "(47) 9 999933-1122",
                    Endereco = "endereço da rua de brusque",
                    Numero = "numero 1500",
                    Complemento = "do lado da FIP",
                    Cep = "88353100",
                    Cidade = "Brusque",
                    Estado = "SC",
                    Observacao = "Observação da empresa",
                    Inativo = false
                };

                string insertSql = @"
                            INSERT INTO Empresa (Id_Tenant, Referencia, Descricao, RazaoSocial, NomeFantasia, Cnpj, DataCadastro, PessoaContato, Email, Telefone, Endereco, Numero, Complemento, Cep, Cidade, Estado, Observacao, Inativo)
                            VALUES (@Id_Tenant, @Referencia, @Descricao, @RazaoSocial, @NomeFantasia, @Cnpj, @DataCadastro, @PessoaContato, @Email, @Telefone, @Endereco, @Numero, @Complemento, @Cep, @Cidade, @Estado, @Observacao, @Inativo)";

                dbConnection.Execute(insertSql, empresa);
                dbConnection.Close();
            }
        }
    }
}

