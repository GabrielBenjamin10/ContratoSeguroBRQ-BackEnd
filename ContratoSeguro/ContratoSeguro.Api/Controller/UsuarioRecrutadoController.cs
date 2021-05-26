using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Command.Usuarios;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using ContratoSeguro.Dominio.Handlers.Queries;
using ContratoSeguro.Dominio.Handlers.Queries.Usuario;
using ContratoSeguro.Dominio.Queries;
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
    [Route("v1/account/employee")]
    [ApiController]
    public class UsuarioRecrutadoController : ControllerBase
    {

        [Route("reset-password")]
        [HttpPut]
        public GenericCommandResult ResetPasswordAllUsers(
            [FromBody] EsqueciMinhaSenhaCommand command,
            [FromServices] EsqueciMinhaSenhaCommandHandler handler
        )
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            return resultado;
        }

        [Route("signup")]
        //[Authorize(Roles = "Funcionario")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult SignupRecruitedUser(CriarContaRecrutadoCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaRecrutadoCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }


        [Route("lister-recruited")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetRecruited([FromServices] ListarRecrutadoQueryHandler handle)
        {
            ListarRecrutadosQuery query = new ListarRecrutadosQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("search-recruited{nome}")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetSearchRecruited([FromServices] BuscarNomeRecrutadoQueryHandler handle)
        {
            BuscarPorNomeQuery query = new BuscarPorNomeQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

    }
}
