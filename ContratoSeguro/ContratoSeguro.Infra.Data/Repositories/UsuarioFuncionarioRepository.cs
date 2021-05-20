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

        public void Adicionar(Funcionario usuario)
        {
            _context.Funcionario.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Funcionario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarSenha(Funcionario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Funcionario BuscarPorCPF(string cPF)
        {
            return _context.Funcionario.FirstOrDefault(u => u.CPF == cPF);
        }

        public Funcionario BuscarPorEmail(string email)
        {
            
            return _context.Funcionario.FirstOrDefault(u => u.Email == email);
        }

        public Funcionario BuscarPorId(Guid id)
        {
            return _context.Funcionario.FirstOrDefault(p => p.Id == id);
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return _context.Funcionario.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<Funcionario> Listar()
        {
            return _context.Funcionario
                    .AsNoTracking()
                    .OrderBy(u => u.DataCriacao)
                    .ToList();
        }
    }
}
