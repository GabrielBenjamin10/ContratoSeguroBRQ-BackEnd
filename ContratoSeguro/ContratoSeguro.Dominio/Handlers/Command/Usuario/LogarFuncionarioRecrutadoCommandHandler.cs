
using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Repositories;

namespace ContratoSeguro.Dominio.Handlers.Command.Usuario
{
    public class LogarFuncionarioRecrutadoCommandHandler : IHandlerCommand<LogarCommandRecrutado>
    {
        private readonly IRecrutadoRepository _recrutadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public LogarFuncionarioRecrutadoCommandHandler(IRecrutadoRepository recrutadoRepository, IUsuarioRepository usuarioRepository)
        {
            _recrutadoRepository = recrutadoRepository;
            _usuarioRepository = usuarioRepository;
        }
        public ICommandResult Handle(LogarCommandRecrutado command)
        {
            //Command é valido
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Buscar usuario pelo email
            var recrutado = _usuarioRepository.BuscarPorEmail(command.Email);

            //Usuario existe
            if (recrutado == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Validar Senha
            if (!Senha.ValidarSenha(command.Senha, recrutado.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            //retorna true com os dados do usuário
            return new GenericCommandResult(true, "Usuário Logado", recrutado);
        }
    }
}
