using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Repositories;
using ContratoSeguro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly ContratoSeguroContext _context;

        public EmpresaRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(Empresa usuario)
        {
            _context.Empresa.Add(usuario);
            _context.SaveChanges();
        }

        public Empresa BuscarPorCNPJ(string cNPJ)
        {
            return _context.Empresa.FirstOrDefault(u => u.CNPJ == cNPJ);
        }

        public Empresa BuscarPorId(Guid id)
        {
            return _context.Empresa.FirstOrDefault(p => p.Id == id);
        }

        public Empresa BuscarPorNome(string nome)
        {
            return _context.Empresa.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<Empresa> Listar()
        {
            return _context.Empresa
                    .AsNoTracking()
                    .OrderBy(u => u.DataCriacao)
                    .ToList();
        }


    }
}
