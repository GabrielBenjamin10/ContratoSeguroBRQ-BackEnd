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
    public class UsuarioFuncionarioRepository : IUsuarioFuncionarioRepository
    {
        private readonly ContratoSeguroContext _context;

        public UsuarioFuncionarioRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(UserFuncionario usuario)
        {
            _context.UsuariosFuncionario.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(UserFuncionario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarSenha(UserFuncionario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserFuncionario BuscarPorCPF(string cPF)
        {
            return _context.UsuariosFuncionario.FirstOrDefault(u => u.CPF == cPF);
        }

        public UserFuncionario BuscarPorEmail(string email)
        {
            
            return _context.UsuariosFuncionario.FirstOrDefault(u => u.Email == email);
        }

        public UserFuncionario BuscarPorId(Guid id)
        {
            return _context.UsuariosFuncionario.FirstOrDefault(p => p.Id == id);
        }

        public UserFuncionario BuscarPorNome(string nome)
        {
            return _context.UsuariosFuncionario.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<UserFuncionario> Listar()
        {
            return _context.UsuariosFuncionario
                    .AsNoTracking()
                    .OrderBy(u => u.DataCriacao)
                    .ToList();
        }
    }
}
