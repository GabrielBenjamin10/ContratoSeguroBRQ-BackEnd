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
    public class UsuarioEmpresaRepository : IUsuarioEmpresaRepository
    {
        private readonly ContratoSeguroContext _context;

        public UsuarioEmpresaRepository(ContratoSeguroContext context)
        {
            _context = context;
        }

        public void Adicionar(UserEmpresa usuario)
        {
            _context.UsuariosEmpresa.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(UserEmpresa usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarSenha(UserEmpresa usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserEmpresa BuscarPorCNPJ(string cNPJ)
        {
            return _context.UsuariosEmpresa.FirstOrDefault(u => u.CNPJ == cNPJ);
        }

        public UserEmpresa BuscarPorEmail(string email)
        {
            return _context.UsuariosEmpresa.FirstOrDefault(u => u.Email == email);

        }

        public UserEmpresa BuscarPorId(Guid id)
        {
            return _context.UsuariosEmpresa.FirstOrDefault(p => p.Id == id);
        }

        public UserEmpresa BuscarPorNome(string nome)
        {
            return _context.UsuariosEmpresa.FirstOrDefault(p => p.Nome == nome);
        }

        public ICollection<UserEmpresa> Listar()
        {
            return _context.UsuariosEmpresa
                    .AsNoTracking()
                    .OrderBy(u => u.DataCriacao)
                    .ToList();
        }
    }
}
