using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Handlers.Command.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ContratoSeguro.Dominio.Entidades;

namespace ContratoSeguro.Api.Controller
{
    [Route("api/account")]
    [ApiController]
    public class LogarFuncionarioRecrutado : ControllerBase
    {
        /// <summary>
        /// Esse método loga o funcionario/recrutado no sistema
        /// </summary>
        /// <param name="command">Command de logar funcionario/recrutado</param>
        /// <param name="handler">Command de logar funcionario/recrutad</param>
        /// <returns>Retorna o token</returns>
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommandRecrutadoFuncionario command, [FromServices] LogarRecrutadoFuncionarioCommandHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);
            
            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);

        }
        /// <summary>
        /// Esse método gera o JWT
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>Token</returns>
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaContratoSeguro"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Tipo.ToString()),
                new Claim("role", userInfo.Tipo.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "contratoSeguro",
                    "contratoSeguro",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
}
    }
