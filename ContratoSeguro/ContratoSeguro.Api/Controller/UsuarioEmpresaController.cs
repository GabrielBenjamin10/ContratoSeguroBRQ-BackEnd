using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratoSeguro.Api.Controller
{
    [Route("api/account/company")]
    [ApiController]
    public class UsuarioEmpresaController : ControllerBase
    {
        [Route("signup")]
        //[Authorize(Roles = "")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult SignupCompanyUser(CriarContaEmpresaCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaEmpresaCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
