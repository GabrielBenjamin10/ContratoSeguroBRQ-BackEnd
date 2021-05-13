using ContratoSeguro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ContratoSeguro.Dominio.Commands.Usuarios
{
    public class LogarCommandRecrutado : Notifiable, ICommand
    {
        public LogarCommandRecrutado(string cpf, string email, string senha)
        {
            Email = email;
            Senha = senha;
            Cpf = cpf;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
             .Requires()
             .IsEmail(Email, "Email", "Informe um e-mail válido")
             .HasMinLen(Senha, 6, "Nome", "A senha deve ter pelo menos 6 caracteres")
             .HasMinLen(Cpf, 11, "CPF", "Nome deve conter pelo menos 11 caracteres.")
             .HasMaxLen(Cpf, 11, "CPF", "Nome deve conter no máximo 11 caracteres.")
                );
        }

    }
}