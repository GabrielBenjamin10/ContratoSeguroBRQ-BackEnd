﻿
using ContratoSeguro.Comum.Enum;
using ContratoSeguro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Queries
{
    public class ListarRecrutadosQuery : IQuery
    {
        public void Validar()
        {

        }

        public class ListarRecrutadosQueryResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Telefone { get; set; }
            public string CPF { get; set; }

        }

    }
    
    
}