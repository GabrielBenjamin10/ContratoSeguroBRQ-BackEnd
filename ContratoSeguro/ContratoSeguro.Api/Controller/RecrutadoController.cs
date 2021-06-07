using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Command.Usuarios;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using ContratoSeguro.Dominio.Handlers.Queries;
using ContratoSeguro.Dominio.Handlers.Queries.Usuario;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Queries.Usuario;
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
    [Route("v1/account/recruited")]
    [ApiController]
    public class RecrutadoController : ControllerBase
    {

        /// <summary>
        /// Esse método cadastra um recrutado
        /// </summary>
        /// <param name="command">Command de Cadastrar recrutado</param>
        /// <param name="handler">Hanldler de Cadastrar recrutado</param>
        /// <returns>Retorna o recrutado cadastrado</returns>
        [Route("signup-recruited")]
        //[Authorize(Roles = "Funcionario")]
        [HttpPost]
        public GenericCommandResult SignupRecruitedUser(CriarContaRecrutadoCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaRecrutadoCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Esse método lista todos os recrutados
        /// </summary>
        /// <param name="handle">Handler</param>
        /// <returns>Lista de recrutados</returns>
        [Route("lister-recruited")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetRecruited([FromServices] ListarRecrutadoQueryHandler handle)
        {
            ListarRecrutadosQuery query = new ListarRecrutadosQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        /// <summary>
        /// Essse método busca por um nome de recrutado
        /// </summary>
        /// <param name="handle">Handler</param>
        /// <returns>Retorna a lista de nomes encontrados</returns>
        [Route("search-recruited/{nome}")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetSearchRecruited(string nome, [FromServices] BuscarPorNomeRecrutadoQueryHandler handle)
        {
            BuscarPorNomeRecrutadoQuery query = new BuscarPorNomeRecrutadoQuery();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            query.Nome = nome;

            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("profile-recruited/{id}")]
        [HttpGet]
        public GenericQueryResult GetProfile(Guid id,
           [FromServices] ListarDadosRecrutadoQueryHandler handler
           )
        {
            ListarDadosRecrutadoQuery query = new ListarDadosRecrutadoQuery();

            if (id == Guid.Empty)
                return new GenericQueryResult(false, "Informe um id válido", null);
            query.IdRecrutado = id;

            return (GenericQueryResult)handler.Handle(query);
        }

        [HttpDelete("delete-recruited")]
        [Authorize(Roles = "Funcionario")]
        public GenericCommandResult DeleteRecruited(
                    [FromBody] DeletarRecrutadoCommand command,
                                    [FromServices] DeletarRecrutadoCommandHandler handler
      )
        {

            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
