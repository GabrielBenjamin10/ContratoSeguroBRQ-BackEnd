using ContratoSeguro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Commands.Documentos
{
    public class EnviarArquivoCommand : Notifiable, ICommand
    {
        public EnviarArquivoCommand(DateTime dataExpiracao, string nomeDestinatario, string emailDestinatario)
        {
            DataExpiracao = dataExpiracao;
            NomeDestinatario = nomeDestinatario;
            EmailDestinatario = emailDestinatario;
        }

        public DateTime DataExpiracao { get; set; }
        public string NomeDestinatario { get; set; }
        public string EmailDestinatario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .HasMinLen(NomeDestinatario, 3, "NomeDestinatario", "Nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(NomeDestinatario, 40, "NomeDestinatario", "Nome deve conter até 40 caracteres")
              .IsEmail(EmailDestinatario, "EmailDestinatario", "Informe um e-mail válido")
              );
        }
    }
}
