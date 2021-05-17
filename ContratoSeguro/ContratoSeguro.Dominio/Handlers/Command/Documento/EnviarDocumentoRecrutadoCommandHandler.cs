using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Dominio.Repositories;
using ContratoSeguro.Dominio.Repositories.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Handlers.Command.Documento
{
    public class EnviarDocumentoRecrutadoCommandHandler : IHandlerCommand<EnviarDocumentoRecrutadoCommand>
    {
        private readonly IDocumentoRecrutado _documentoRepositorio;
        private readonly IUsuarioFuncionarioRepository _usuarioFuncionarioRepositorio;
        public ICommandResult Handle(EnviarDocumentoRecrutadoCommand command)
        {
            //Validar dados
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", command.Notifications);

            //Verifica se existe docuemnto com o mesmo nome
            var documentoExiste = _documentoRepositorio.BuscarPorNomeDocumento(command.NomeDocumento);

            if (documentoExiste != null)
                return new GenericCommandResult(true, "Nome do documento já cadastrado", null);

            //Gerar instancia do Pacote
            var documentoRecrutado = new Entidades.DocumentoRecrutado(command.NomeDocumento, command.Sentimento, command.DataExpiracao, command.Sucesso, command.IdUsuarioFuncionario, command.Status);

            if (documentoRecrutado.Invalid)
                return new GenericCommandResult(true, "Dados inválidos", documentoRecrutado.Notifications);

            if (!string.IsNullOrEmpty(command.Email))
                documentoRecrutado.AdicionarDestinatario(command.Email, command.Nome);

            if (documentoRecrutado.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", documentoRecrutado.Notifications);

            //Adicionar pacote
            _documentoRepositorio.Adicionar(documentoRecrutado);

            //Retornar sucesso
            return new GenericCommandResult(true, "Documento criado", documentoRecrutado);
        }
    }
}
