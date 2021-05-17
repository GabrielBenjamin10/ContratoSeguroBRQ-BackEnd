using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Repositories;
using ContratoSeguro.Dominio.Repositories.Documento;
using ContratoSeguro.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Infra.Data.Repositories
{
    public class DocumentoRecrutadoRepository : IDocumentoRecrutado
    {
        private readonly ContratoSeguroContext _context;

        public DocumentoRecrutadoRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(DocumentoRecrutado documentoRecrutado)
        {
            _context.DocumentosRecrutado.Add(documentoRecrutado);
            _context.SaveChanges();
        }

        public DocumentoRecrutado BuscarPorEmail(string email)
        {
            return _context.DocumentosRecrutado.FirstOrDefault(u => u.Email == email);
        }

        public DocumentoRecrutado BuscarPorId(Guid id)
        {
            return _context.DocumentosRecrutado.FirstOrDefault(u => u.Id == id);

        }

        public DocumentoRecrutado BuscarPorNomeDocumento(string NomeDocumento)
        {
            return _context.DocumentosRecrutado.FirstOrDefault(u => u.NomeDocumento == NomeDocumento);

        }

        public IEnumerable<DocumentoRecrutado> ListarAguardando(bool? aguardando = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentoRecrutado> ListarEnviado(bool? enviado = null)
        {
            throw new NotImplementedException();
        }
    }
}
