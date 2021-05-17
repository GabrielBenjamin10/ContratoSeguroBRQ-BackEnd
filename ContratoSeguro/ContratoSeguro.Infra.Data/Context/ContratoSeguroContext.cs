using ContratoSeguro.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Infra.Data.Context
{
    public class ContratoSeguroContext : DbContext
    {
        public ContratoSeguroContext(DbContextOptions<ContratoSeguroContext> options) :
           base(options)
        {

        }
        public DbSet<UserFuncionario> UsuariosFuncionario { get; set; }
        public DbSet<UserRecrutado> UsuariosRecrutado { get; set; }
        public DbSet<UserEmpresa> UsuariosEmpresa { get; set; }
        public DbSet<DocumentoRecrutado> DocumentosRecrutado { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Notification>();

            #region Mapeamento Tabela Usuários Recrutado
            modelBuilder.Entity<UserRecrutado>().ToTable("UsuariosRecrutado");
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<UserRecrutado>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<UserRecrutado>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<UserRecrutado>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<UserRecrutado>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //CPF
            modelBuilder.Entity<Dominio.Entidades.UserRecrutado>().Property(x => x.CPF).HasMaxLength(100);
            modelBuilder.Entity<UserRecrutado>().Property(x => x.CPF).HasColumnType("varchar(100)");

            //DataCriacao
            modelBuilder.Entity<UserRecrutado>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<UserRecrutado>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<UserRecrutado>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<UserRecrutado>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion

            #region Mapeamento Tabela Usuários Funcionario
            modelBuilder.Entity<UserFuncionario>().ToTable("UsuariosFuncionario");
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //RG
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.RG).HasMaxLength(20);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.RG).HasColumnType("varchar(20)");

            //Formação
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Formação).HasMaxLength(100);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.Formação).HasColumnType("varchar(100)");

            //DataNascimento
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.DataNascimento).HasMaxLength(100);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.DataNascimento).HasColumnType("varchar(100)");

            //CPF
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.CPF).HasMaxLength(100);
            modelBuilder.Entity<UserFuncionario>().Property(x => x.CPF).HasColumnType("varchar(100)");

            //DataCriacao
            modelBuilder.Entity<UserFuncionario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<UserFuncionario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<UserFuncionario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<UserFuncionario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion

            #region Mapeamento Tabela Usuários Empresa
            modelBuilder.Entity<UserEmpresa>().ToTable("UsuariosEmpresa");
            modelBuilder.Entity<Dominio.Entidades.UserFuncionario>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //CNPJ
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.CNPJ).HasMaxLength(14);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.CNPJ).HasColumnType("varchar(14)");

            //Razao social
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.RazaoSocial).HasMaxLength(100);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.RazaoSocial).HasColumnType("varchar(100)");

            //Matriz
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Matriz).HasMaxLength(100);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Matriz).HasColumnType("varchar(100)");

            //Logradouro
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Logradouro).HasMaxLength(100);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Logradouro).HasColumnType("varchar(100)");

            //UF
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.UF).HasMaxLength(100);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.UF).HasColumnType("varchar(100)");

            //Cidade
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Cidade).HasMaxLength(50);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Cidade).HasColumnType("varchar(50)");

            //Numero
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Numero).HasMaxLength(50);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Numero).HasColumnType("varchar(50)");

            //Bairro
            modelBuilder.Entity<Dominio.Entidades.UserEmpresa>().Property(x => x.Numero).HasMaxLength(50);
            modelBuilder.Entity<UserEmpresa>().Property(x => x.Numero).HasColumnType("varchar(50)");

            //DataAbertuma
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataAbertura).HasColumnType("DateTime");
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataAbertura).HasDefaultValueSql("GetDate()");

            //DataCriacao
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<UserEmpresa>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion

            #region Mapeamento Tabela Documento Recrutado
            modelBuilder.Entity<DocumentoRecrutado>().ToTable("DocumentoRecrutado");
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Id);

            //NomeDocumento
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.NomeDocumento).HasMaxLength(100);
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Nome).HasColumnType("varchar(100)");
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Nome).IsRequired();

            //Sentimento
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Sentimento).HasMaxLength(80);
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Email).HasColumnType("varchar(80)");
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Email).IsRequired();

            //Sucesso
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Sucesso).HasColumnType("bit");

            //Status
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Status).HasColumnType("int");

            //Nome
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<DocumentoRecrutado>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Dominio.Entidades.DocumentoRecrutado>().Property(x => x.Email).IsRequired();

            //DataCriacao
            modelBuilder.Entity<DocumentoRecrutado>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<DocumentoRecrutado>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<DocumentoRecrutado>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<DocumentoRecrutado>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion

            base.OnModelCreating(modelBuilder);



        }
    }
}
