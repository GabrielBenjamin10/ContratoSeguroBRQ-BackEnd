using ContratoSeguro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Commands.Usuarios
{
    public class AlterarSenhaCommand : Notifiable, ICommand
    {
        public AlterarSenhaCommand()
        {

        }
        public AlterarSenhaCommand(string senha)
        {
            Senha = senha;
        }

        public Guid IdUsuario { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe um id de usuário valido")
                .IsEmail(Senha, "Email", "informe um e-mail válido")
                );
        }
    }
}
