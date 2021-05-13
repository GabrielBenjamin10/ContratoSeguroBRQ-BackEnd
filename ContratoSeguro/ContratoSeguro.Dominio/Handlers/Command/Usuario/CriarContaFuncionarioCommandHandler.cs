﻿using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Handlers.Command.Usuario
{
     public class CriarContaFuncionarioCommandHandler : Notifiable, IHandlerCommand<CriarContaFuncionarioCommand>
    {
        private readonly IUsuarioFuncionarioRepository _usuarioFuncionarioRepositorio;
        public CriarContaFuncionarioCommandHandler(IUsuarioFuncionarioRepository usuarioFuncionarioRepositorio)
        {
            _usuarioFuncionarioRepositorio = usuarioFuncionarioRepositorio;
        }

        public ICommandResult Handle(CriarContaFuncionarioCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do usuário Inválidos", command.Notifications);

            //Verifica se cpf existe
            var cpfExiste = _usuarioFuncionarioRepositorio.BuscarPorCPF(command.CPF);
            if (cpfExiste != null)
                return new GenericCommandResult(false, "CPF já cadastrado", null);

            //Verifica se email existe
            var usuarioExiste = _usuarioFuncionarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //Criptografar Senha 
            command.Senha = Senha.Criptografar(command.Senha);

            //Salvar Usuário
            var usuario = new Entidades.UserFuncionario(command.Nome, command.Email, command.Senha,  command.TipoUsuario, command.CPF, command.RG, command.Formação, command.DataNascimento);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications);

            _usuarioFuncionarioRepositorio.Adicionar(usuario);

            //Enviar Email de Boas Vindas
            //Send Grid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}