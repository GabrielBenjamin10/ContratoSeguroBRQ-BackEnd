using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Utills;
using ContratoSeguro.Dominio.Commands.Documentos;
using ContratoSeguro.Dominio.Handlers.Command.Documento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContratoSeguro.Api.Controller
{
    [Route("api/document")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        [Route("upload/{id}")]
        //[Authorize(Roles = "Funcionario")]
        [HttpPost]
        public ICommandResult Arquivo( IFormFile arquivo)
        ////Definimos que o CriarContaHanlde é um serviço
        {
            if (arquivo == null)
                return new GenericCommandResult(false, "Envie um arquivo!", null);

            var urlIdocumento = Upload.Local(arquivo);

            return new GenericCommandResult(true, "Upload concluído com sucesso!", urlIdocumento);
        }
    }
}
