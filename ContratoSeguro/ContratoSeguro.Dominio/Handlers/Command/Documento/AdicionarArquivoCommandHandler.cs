using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Dominio.Commands.Documentos;
using ContratoSeguro.Dominio.Repositories;
using Flunt.Notifications;


namespace ContratoSeguro.Dominio.Handlers.Command.Documento
{
    public class AdicionarArquivoCommandHandler : Notifiable, IHandlerCommand<AdicionarArquivoCommand>
    {
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IRecrutadoRepository _recrutadoRepository;
        //Injeção de dependência
        public AdicionarArquivoCommandHandler(IDocumentoRepository documentoRepository, IRecrutadoRepository recrutadoRepository)
        {
            _documentoRepository = documentoRepository;
            _recrutadoRepository = recrutadoRepository;
        }

        public ICommandResult Handle(AdicionarArquivoCommand command)
        {
            // Validar Command
            command.Validar();

            var recrutado = _recrutadoRepository.BuscarPorId(command.IdRecrutado);

            if (recrutado == null)
                return new GenericCommandResult(false, "Recrutado não encontrado ", null);

            var arquivo = new Entidades.Documento(command.UrlArquivo);


            _documentoRepository.AdicionarArquivo(arquivo);


            return new GenericCommandResult(true, "Sucesso!", null);
        }
    }
}
