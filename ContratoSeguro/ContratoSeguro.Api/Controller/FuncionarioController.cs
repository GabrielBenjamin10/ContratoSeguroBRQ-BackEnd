using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using ContratoSeguro.Dominio.Handlers.Queries;
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
    [Route("api/account/employee")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Esse método cadastra um funcionario
        /// </summary>
        /// <param name="command">Command de cadastrar funcionario</param>
        /// <param name="handler">Handler de cadastrar funcionario</param>
        /// <returns>Retorna o cadastro do funcionario</returns>
        [Route("signup")]
        //[Authorize(Roles = "Empresa")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult SignupEmployeeUser(CriarContaFuncionarioCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaFuncionarioCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Esse método lista os usuários do tipo funcionario
        /// </summary>
        /// <param name="handle">Handler</param>
        /// <returns>Funcionarios cadastrados</returns>
        [Route("lister-employee")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetEmployee([FromServices] ListarFuncionarioQueryHandler handle)
        {
            ListarFuncionarioQuery query = new ListarFuncionarioQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("profile-employee/{id}")]
        [HttpGet]
        public GenericQueryResult GetProfile(Guid id,
           [FromServices] ListarDadosFuncionarioQueryHandler handler
           )
        {
            ListarDadosFuncionarioQuery query = new ListarDadosFuncionarioQuery();

            if (id == Guid.Empty)
                return new GenericQueryResult(false, "Informe um id válido", null);
            query.IdFuncionario = id;

            return (GenericQueryResult)handler.Handle(query);
        }

        /// <summary>
        /// Essse método busca por um nome de recrutado
        /// </summary>
        /// <param name="handle">Handler</param>
        /// <returns>Retorna a lista de nomes encontrados</returns>
        [Route("search-employee/{nome}")]
        //[Authorize(Roles = "Funcionario")]
        [HttpGet]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericQueryResult GetSearchEmployee(string nome, [FromServices] BuscarPorNomeFuncionarioQueryHandler handle)
        {
            BuscarNomeFuncionarioQuery query = new BuscarNomeFuncionarioQuery();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            query.Nome = nome;

            return (GenericQueryResult)handle.Handle(query);
        }


    }
}
