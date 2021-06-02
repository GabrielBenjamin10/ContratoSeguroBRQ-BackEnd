using ContratoSeguro.Comum.Entidades;
using Flunt.Br.Extensions;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Entidades
{
    public class Documento : Entidade
    {
        public Documento(string urlArquivo)
        {
            UrlArquivo = urlArquivo;
        }
        public string Nome { get; set; }
        public string UrlArquivo { get; set; }
        public virtual Usuario Usuario { get; private set; }  
    }
}
