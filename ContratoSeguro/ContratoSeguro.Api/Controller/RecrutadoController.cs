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
        /// Esse método loga o funcionario/recrutado no sistema
        /// </summary>
        /// <param name="command">Command de logar funcionario/recrutado</param>
        /// <param name="handler">Command de logar funcionario/recrutad</param>
        /// <returns>Retorna o token</returns>
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommandRecrutado command, [FromServices] LogarRecrutadoCommandHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Recrutado)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);

        }
        /// <summary>
        /// Esse método gera o JWT
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>Token</returns>
        private string GerarJSONWebToken(Recrutado userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaContratoSeguroApi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.CPF),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Tipo.ToString()),
                new Claim("role", userInfo.Tipo.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.IdUsuario.ToString()),


            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "contratoseguro",
                    "contratoseguro",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

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
