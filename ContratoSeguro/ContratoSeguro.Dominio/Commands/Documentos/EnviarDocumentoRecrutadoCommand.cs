using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Handlers.Command
{
    public class EnviarDocumentoRecrutadoCommand : Notifiable, ICommand
    {
        public EnviarDocumentoRecrutadoCommand()
        {

        }

        public EnviarDocumentoRecrutadoCommand(string nomeDocumento, string sentimento, DateTime dataExpiracao, bool sucesso, Guid idUsuarioFuncionario, EnStatusDocumento status)
        {
            NomeDocumento = nomeDocumento;
            Sentimento = sentimento;
            DataExpiracao = dataExpiracao;
            Sucesso = sucesso;
            IdUsuarioFuncionario = idUsuarioFuncionario;
            Status = status;
        }

        public string NomeDocumento { get; set; }
        public string Sentimento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Sucesso { get; set; }
        public Guid IdUsuarioFuncionario { get; private set; }
        public EnStatusDocumento Status { get;  set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeDocumento, "NomeDOcuemnto", "Informe o nome do docuemnto")
                .IsNotNullOrEmpty(Sentimento, "Sentimento", "Informe o sentimento do documento")
                .AreNotEquals(IdUsuarioFuncionario, Guid.Empty, "IdUsuarioFuncionario", "Informe o Id do Usuário do documento")
            );
        }
    }
}
