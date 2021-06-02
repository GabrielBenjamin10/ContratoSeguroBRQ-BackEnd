using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IDocumentoRepository 
    {
        void AdicionarArquivo(Documento arquivo);
    }
}
