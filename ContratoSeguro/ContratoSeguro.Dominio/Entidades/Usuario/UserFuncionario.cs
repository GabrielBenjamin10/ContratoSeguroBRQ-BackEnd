using ContratoSeguro.Comum.Entidades;
using ContratoSeguro.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Entidades
{
    public class UserFuncionario : Entidade
    {
        public UserFuncionario(string nome, string email, string senha, EnTipoUsuario tipoUsuario, string cPF, string rG, string formação, DateTime dataNascimento)
        {

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(nome, 40, "Nome", "Nome deve conter no máximo 40 caracteres.")
                .IsEmail(email, "Email", "Informe um e-mail válido")
                .HasMinLen(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres.")
                .HasMinLen(cPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
                .HasMinLen(rG, 9, "RG", "O seu numero de RG deve conter no minimo e no maximo 9 digitos.")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
                CPF = cPF;
                RG = rG;
                Formação = formação;
                DataNascimento = dataNascimento;
            }

        }

        public string CPF { get; set; }
        public string RG { get; set; }
        public string Formação { get; set; }
        public DateTime DataNascimento { get; set; }

        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 8, "Senha", "Senha deve ter no minímo 8 caracteres")
            );

            if (Valid)
                Senha = senha;
        }
    }
}
