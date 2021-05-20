using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Api.Controller
{
    [Route("api/account/employee")]
    [ApiController]
    public class UsuarioFuncionarioController : ControllerBase
    {

        [Route("signup")]
        [Authorize(Roles = "Empresa")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult SignupEmployeeUser(CriarContaFuncionarioCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaFuncionarioCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }

        
    }
}
