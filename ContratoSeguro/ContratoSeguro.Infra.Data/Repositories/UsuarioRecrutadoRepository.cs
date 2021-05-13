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

        public void Adicionar(UserRecrutado usuario)
        {
            _context.UsuariosRecrutado.Add(usuario);
            _context.SaveChanges();
        }
        public void Alterar(UserRecrutado usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void AlterarSenha(UserRecrutado usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserRecrutado BuscarPorEmail(string email)
        {
            return _context.UsuariosRecrutado.FirstOrDefault(u => u.Email == email);
        }
        public UserRecrutado BuscarPorCPF(string cPF)
        {
            return _context.UsuariosRecrutado.FirstOrDefault(u => u.CPF == cPF);
        }

        public UserRecrutado BuscarPorId(Guid id)
        {
            return _context.UsuariosRecrutado.FirstOrDefault(p => p.Id == id);

        }

        public UserRecrutado BuscarPorNome(string nome)
        {
            return _context.UsuariosRecrutado.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<UserRecrutado> Listar()
        {
            return _context.UsuariosRecrutado
                     .AsNoTracking()
                     .OrderBy(u => u.DataCriacao)
                     .ToList();
        }
    }
}
