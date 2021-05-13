using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Dominio.Command.Usuarios;
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

        /// <summary>
        /// Cadastra um recrutado
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns>Usuario cadastrado</returns>
        [Route("signup")]
        //[Authorize(Roles = "Empresa")]
        [HttpPost]
        //Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult SignupRecruitedUser(CriarContaRecrutadoCommand command,
        ////Definimos que o CriarContaHanlde é um serviço
        [FromServices] CriarContaRecrutadoCommandHandler handler)
        {

            return (GenericCommandResult)handler.Handle(command);
        }


        // Criamos nosso método que vai gerar nosso Token
        private string GerarJSONWebToken(UserRecrutado userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaContratoSeguroApi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
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
    }
}
