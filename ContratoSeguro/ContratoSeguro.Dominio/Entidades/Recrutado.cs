﻿using ContratoSeguro.Comum.Entidades;
using ContratoSeguro.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Entidades
{
    public class Recrutado : Usuario
    {
        //Atributos Recrutado
        public List<Recrutado> _recrutado { get; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        


        public Recrutado(string nome, string email, string senha, string cPF, EnTipoUsuario tipo)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(nome, 40, "Nome", "Nome deve conter no máximo 40 caracteres.")
                .IsEmail(email, "Email", "Informe um e-mail válido")
                .HasMinLen(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres.")
                .HasMinLen(cPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                CPF = cPF;
                Tipo = tipo;
            }

        } 
    
    }

}