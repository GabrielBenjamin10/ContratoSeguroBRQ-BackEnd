using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IUsuarioEmpresaRepository
    {
        void Adicionar(Empresa usuario);
        void AlterarSenha(Empresa usuario);
        void Alterar(Empresa usuario);
        Empresa BuscarPorEmail(string email);
        Empresa BuscarPorCNPJ(string cNPJ);
        Empresa BuscarPorId(Guid id);
        Empresa BuscarPorNome(string nome);

        ICollection<Empresa> Listar();
    }
}
