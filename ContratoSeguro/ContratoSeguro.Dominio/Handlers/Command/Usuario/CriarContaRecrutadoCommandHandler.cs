using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Command.Usuarios;
using ContratoSeguro.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratoSeguro.Dominio.Handlers.Command.Usuario
{
    public class CriarContaRecrutadoCommandHandler : Notifiable, IHandlerCommand<CriarContaRecrutadoCommand>
    {
        private readonly IUsuarioRecrutadoRepository _usuarioRecrutadoRepositorio;
        public CriarContaRecrutadoCommandHandler(IUsuarioRecrutadoRepository usuarioRecrutadoRepositorio)
        {
            _usuarioRecrutadoRepositorio = usuarioRecrutadoRepositorio;
        }

        public ICommandResult Handle(CriarContaRecrutadoCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do usuário Inválidos", command.Notifications);

            //Verifica se email existe
            var cpfExiste = _usuarioRecrutadoRepositorio.BuscarPorCPF(command.CPF);
            if (cpfExiste != null)
                return new GenericCommandResult(false, "CPF já cadastrado", null);

            //Verifica se email existe
            var usuarioExiste = _usuarioRecrutadoRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //Criptografar Senha 
            command.Senha = Senha.Criptografar(command.Senha);

            //Salvar Usuário
            var usuario = new Entidades.Recrutado(command.Nome, command.Email, command.Senha, command.CPF, command.Tipo);
            if (usuario.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications);

            _usuarioRecrutadoRepositorio.Adicionar(usuario);
            //Enviar Email de Boas Vindas
            //Send Grid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
