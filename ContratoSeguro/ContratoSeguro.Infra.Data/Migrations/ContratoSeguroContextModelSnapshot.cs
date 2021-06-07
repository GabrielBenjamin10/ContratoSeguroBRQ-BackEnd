﻿// <auto-generated />
using System;
using ContratoSeguro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContratoSeguro.Infra.Data.Migrations
{
    [DbContext(typeof(ContratoSeguroContext))]
    partial class ContratoSeguroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Documento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailDestinatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("NomeDestinatario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlArquivo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Empresa", b =>
                {
                    b.HasBaseType("ContratoSeguro.Dominio.Entidades.Usuario");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataAbertura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Matriz")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Funcionario", b =>
                {
                    b.HasBaseType("ContratoSeguro.Dominio.Entidades.Usuario");

                    b.Property<string>("CPF")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Formação")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RG")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Recrutado", b =>
                {
                    b.HasBaseType("ContratoSeguro.Dominio.Entidades.Usuario");

                    b.Property<string>("CPF")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("RecrutadoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("RecrutadoId");

                    b.ToTable("Recrutados");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Documento", b =>
                {
                    b.HasOne("ContratoSeguro.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Documentos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Empresa", b =>
                {
                    b.HasOne("ContratoSeguro.Dominio.Entidades.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ContratoSeguro.Dominio.Entidades.Empresa", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Funcionario", b =>
                {
                    b.HasOne("ContratoSeguro.Dominio.Entidades.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ContratoSeguro.Dominio.Entidades.Funcionario", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Recrutado", b =>
                {
                    b.HasOne("ContratoSeguro.Dominio.Entidades.Usuario", null)
                        .WithOne()
                        .HasForeignKey("ContratoSeguro.Dominio.Entidades.Recrutado", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ContratoSeguro.Dominio.Entidades.Recrutado", null)
                        .WithMany("_recrutado")
                        .HasForeignKey("RecrutadoId");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Documentos");
                });

            modelBuilder.Entity("ContratoSeguro.Dominio.Entidades.Recrutado", b =>
                {
                    b.Navigation("_recrutado");
                });
#pragma warning restore 612, 618
        }
    }
}
