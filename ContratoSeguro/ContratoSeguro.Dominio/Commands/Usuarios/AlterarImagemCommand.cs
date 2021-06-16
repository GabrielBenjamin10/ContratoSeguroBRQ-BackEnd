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
    public class AlterarImagemCommand : Notifiable, ICommand
    {
        public AlterarImagemCommand(Guid idUsuario, string urlFoto)
        {
            IdUsuario = idUsuario;
            UrlFoto = urlFoto;
        }
        public Guid IdUsuario { get; set; }
        public string UrlFoto { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe um id de usuário valido")
                .IsNotNullOrEmpty(UrlFoto, "UrlFoto", "Informe a imagem do pacote")
                );
        }
    }
}
