
using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Repositories;

namespace ContratoSeguro.Dominio.Handlers.Command.Usuario
{
    public class LogarRecrutadoFuncionarioCommandHandler : IHandlerCommand<LogarCommandRecrutadoFuncionario>
    {
        private readonly IRecrutadoRepository _recrutadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public LogarRecrutadoFuncionarioCommandHandler(IRecrutadoRepository recrutadoRepository, IUsuarioRepository usuarioRepository)
        {
            _recrutadoRepository = recrutadoRepository;
            _usuarioRepository = usuarioRepository;
        }
        public ICommandResult Handle(LogarCommandRecrutadoFuncionario command)
        {
            //Command é valido
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Buscar usuario pelo email
            var usuario = _usuarioRepository.BuscarPorEmail(command.Email);

            //Usuario existe
            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Validar Senha
            if (!Senha.ValidarSenha(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            //retorna true com os dados do usuário
            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
