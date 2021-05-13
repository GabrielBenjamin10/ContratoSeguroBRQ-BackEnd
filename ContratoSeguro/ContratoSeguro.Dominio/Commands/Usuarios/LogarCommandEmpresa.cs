using ContratoSeguro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ContratoSeguro.Dominio.Commands.Usuarios
{
    public class LogarCommand : Notifiable, ICommand
    {
        public LogarCommand(string cnpj, string email, string senha)
        {
            Email = email;
            Senha = senha;
            Cnpj = cnpj;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cnpj { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
             .Requires()
             .IsEmail(Email, "Email", "Informe um e-mail válido")
             .HasMinLen(Senha, 6, "Nome", "A senha deve ter pelo menos 6 caracteres")
             .HasMinLen(Cnpj, 11, "CPF", "Nome deve conter pelo menos 11 caracteres.")
             .HasMaxLen(Cnpj, 11, "CPF", "Nome deve conter no máximo 11 caracteres.")
                );
        }

    }
}