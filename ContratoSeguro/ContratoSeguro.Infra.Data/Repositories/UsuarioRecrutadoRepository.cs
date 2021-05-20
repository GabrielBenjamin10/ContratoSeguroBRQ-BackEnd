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
    public class UsuarioRecrutadoRepository : IUsuarioRecrutadoRepository
    {
        private readonly ContratoSeguroContext _context;

        public UsuarioRecrutadoRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(Recrutado usuario)
        {
            _context.Recrutado.Add(usuario);
            _context.SaveChanges();
        }
        public void Alterar(Recrutado usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void AlterarSenha(Recrutado usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Recrutado BuscarPorEmail(string email)
        {
            return _context.Recrutado.FirstOrDefault(u => u.Email == email);
        }
        public Recrutado BuscarPorCPF(string cPF)
        {
            return _context.Recrutado.FirstOrDefault(u => u.CPF == cPF);
        }

        public Recrutado BuscarPorId(Guid id)
        {
            return _context.Recrutado.FirstOrDefault(p => p.Id == id);

        }

        public Recrutado BuscarPorNome(string nome)
        {
            return _context.Recrutado.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<Recrutado> Listar()
        {
            return _context.Recrutado
                     .AsNoTracking()
                     .OrderBy(u => u.DataCriacao)
                     .ToList();
        }
    }
}
