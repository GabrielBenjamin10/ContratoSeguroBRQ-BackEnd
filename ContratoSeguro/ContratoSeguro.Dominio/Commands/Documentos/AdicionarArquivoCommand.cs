using ContratoSeguro.Comum.Commands;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Commands.Documentos
{
    public class AdicionarArquivoCommand : Notifiable, ICommand
    {
        public AdicionarArquivoCommand(string urlArquivo)
        {
            UrlArquivo = urlArquivo;
        }

        public string UrlArquivo { get; set; }
        public Guid IdRecrutado { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(UrlArquivo, "Arquivo", "Envie um arquivo")
               );
        }
    }
}
