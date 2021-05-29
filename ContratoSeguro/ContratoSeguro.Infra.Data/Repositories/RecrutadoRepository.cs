using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Repositories;
using ContratoSeguro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContratoSeguro.Infra.Data.Repositories
{
    public class RecrutadoRepository : IRecrutadoRepository
    {
        private readonly ContratoSeguroContext _context;

        public RecrutadoRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(Recrutado usuario)
        {
            _context.Recrutado.Add(usuario);
            _context.SaveChanges();
        }

        public Recrutado BuscarPorCPF(string cPF)
        {
            return _context.Recrutado.FirstOrDefault(u => u.CPF == cPF);
        }

        public Recrutado BuscarPorNome(string nome)
        {
            //return _context.Recrutado.Find(x => x.Recrutado == nome).FirstOrDefault();
            return _context.Recrutado.FirstOrDefault(u => u.Nome == nome);
        }

        public Recrutado BuscarPorId(Guid id)
        {
            return _context.Recrutado.FirstOrDefault(p => p.Id == id);
        }


        public ICollection<Recrutado> Listar() //ICollection => Lista em forma de array para , posteriormente, modifica-los
        {
            return _context.Recrutado
                     .AsNoTracking()
                     .OrderBy(u => u.DataCriacao)
                     .ToList();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
