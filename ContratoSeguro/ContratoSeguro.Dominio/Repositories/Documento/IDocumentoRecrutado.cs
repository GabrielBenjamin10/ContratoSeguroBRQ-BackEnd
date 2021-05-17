using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Repositories.Documento
{
    public interface IDocumentoRecrutado
    {
        void Adicionar(DocumentoRecrutado documentoRecrutado);
        DocumentoRecrutado BuscarPorId(Guid id);
        DocumentoRecrutado BuscarPorEmail(string email);
        DocumentoRecrutado BuscarPorNomeDocumento(string NomeDocumento);
        IEnumerable<DocumentoRecrutado> ListarAguardando(bool? aguardando = null);
        IEnumerable<DocumentoRecrutado> ListarEnviado(bool? enviado = null);

    }
}
