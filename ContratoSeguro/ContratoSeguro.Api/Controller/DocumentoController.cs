using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Commands.Documentos;
using ContratoSeguro.Dominio.Handlers.Command.Documento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ContratoSeguro.Api.Controller
{
    [Route("api/document")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        [Route("upload")]
        //[Authorize(Roles = "Funcionario")]
        [HttpPost]
        public ICommandResult UploadFiles( IFormFile arquivo)
        ////Definimos que o CriarContaHanlde é um serviço
        {
            if (arquivo == null)
                return new GenericCommandResult(false, "Envie um arquivo!", null);

            var urlIdocumento = Upload.Local(arquivo);

            return new GenericCommandResult(true, "Upload concluído com sucesso!", urlIdocumento);
        }
        [Route("send")]
        [HttpPost]
        public GenericCommandResult SendFiles(
            [FromBody] EnviarArquivoCommand command,
            [FromServices] EnviarArquivoCommandHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
