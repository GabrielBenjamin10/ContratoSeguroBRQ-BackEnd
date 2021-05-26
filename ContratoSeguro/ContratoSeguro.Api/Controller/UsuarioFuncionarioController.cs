﻿using ContratoSeguro.Comum.Commands;
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


    }
}
