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

            base.OnModelCreating(modelBuilder);



        }
    }
}
