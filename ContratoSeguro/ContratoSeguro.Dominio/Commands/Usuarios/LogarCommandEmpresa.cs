using ContratoSeguro.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace ContratoSeguro.Dominio.Commands.Usuarios
{
    public class LogarCommandEmpresa : Notifiable, ICommand
    {
        public LogarCommandEmpresa(string cnpj, string email, string senha)
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
             .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
             .HasMinLen(Cnpj, 14, "Cnpj", "CNPJ deve conter pelo menos 11 caracteres.")
             .HasMaxLen(Cnpj, 14, "Cnpj", "O CNPJ deve conter no máximo 11 caracteres.")
                );
        }

    }
}