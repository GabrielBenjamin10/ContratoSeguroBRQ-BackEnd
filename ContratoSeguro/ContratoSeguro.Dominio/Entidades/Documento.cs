using ContratoSeguro.Comum.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Entidades
{
    public class Documento : Entidade
    {
        public string Nome { get; set; }
        public virtual Usuario Usuario { get; private set; }
    }
}
