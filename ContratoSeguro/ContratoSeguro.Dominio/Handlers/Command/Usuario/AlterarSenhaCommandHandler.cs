using ContratoSeguro.Comum.Commands;
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
    public class AlterarSenhaCommandHandler : Notifiable, IHandlerCommand<AlterarSenhaCommand>
    {
        //Injetando o nosso repositório 
        private readonly IUsuarioRecrutadoRepository _repositorio;

        //Injeção de dependência
        public AlterarSenhaCommandHandler(IUsuarioRecrutadoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método para validar os processos para alterar a senha de um usuário
        /// </summary>
        /// <param name="command">Comando de alterar senha</param>
        /// <returns>Nova senha</returns>
        public ICommandResult Handle(AlterarSenhaCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Senha inválida", command.Notifications);

            var usuarioexiste = _repositorio.BuscarPorId(command.IdUsuario);

            if (usuarioexiste == null)
                return new GenericCommandResult(false, "Usuário não encontrado", command.Notifications);

            //TODO: Criptografar senha
            command.Senha = Senha.Criptografar(command.Senha);

            usuarioexiste.AlterarSenha(command.Senha);

            _repositorio.Alterar(usuarioexiste);


            return new GenericCommandResult(true, "Senha Alterada", null);
        }
    }
}
