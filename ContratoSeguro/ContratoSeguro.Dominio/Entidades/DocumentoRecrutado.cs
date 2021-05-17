using ContratoSeguro.Comum.Entidades.Documentos;
using ContratoSeguro.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Entidades
{
    public class DocumentoRecrutado : EntidadeDocumento
    {
        public DocumentoRecrutado(string nomeDocumento, string sentimento, DateTime dataExpiracao, bool sucesso, Guid idUsuarioFuncionario,  EnStatusDocumento status)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nomeDocumento, "NomeDOcuemnto", "Informe o nome do docuemnto")
                .IsNotNullOrEmpty(sentimento, "Sentimento", "Informe o sentimento do documento")
                .AreNotEquals(idUsuarioFuncionario, Guid.Empty, "IdUsuarioFuncionario", "Informe o Id do Usuário do documento")
            );

            if(Valid)
            {
                NomeDocumento = nomeDocumento;
                Sentimento = sentimento;
                DataExpiracao = dataExpiracao;
                Sucesso = sucesso;
                IdUsuarioFuncionario = idUsuarioFuncionario;
                Status = status;
            }
            
        }

        private readonly List<DocumentoRecrutado> _documentoRecrutado;
        public string NomeDocumento { get; set; }
        public string Sentimento { get; set; }
        public bool Sucesso { get; set; }
        public DateTime DataExpiracao { get; set; }
        public Guid IdUsuarioFuncionario { get; private set; }
        public virtual UserFuncionario UsuarioFuncionario { get; private set; }
        public EnStatusDocumento Status { get;  set; }
        public string Email { get; set; }
        public string Nome { get; set; }


        public void AdicionarDestinatario(string nome, string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome do destinatario")
                .HasMinLen(nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                .IsEmail(email, "Email", "Informe um email válido")
                );
            if (Valid)
                Nome = nome;
                Email = email;

        }

        public void ExcluirDestinatario(DocumentoRecrutado destinatario)
        {
            if (Valid)
                _documentoRecrutado.Remove(destinatario);
        }

    }
        
}
