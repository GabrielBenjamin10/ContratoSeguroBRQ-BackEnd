using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Dominio.Handlers.Command;
using ContratoSeguro.Dominio.Handlers.Command.Documento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoSeguro.Api.Controller
{
    [Route("v1/document")]
    [ApiController]
    public class DocumentoRecrutadoController : ControllerBase
    {
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public GenericCommandResult CreateDocument(EnviarDocumentoRecrutadoCommand command,
                                                [FromServices] EnviarDocumentoRecrutadoCommandHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
