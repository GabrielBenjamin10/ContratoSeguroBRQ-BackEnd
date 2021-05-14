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
        void Adicionar(UserEmpresa usuario);
        void AlterarSenha(UserEmpresa usuario);
        void Alterar(UserEmpresa usuario);
        UserEmpresa BuscarPorEmail(string email);
        UserEmpresa BuscarPorCNPJ(string cNPJ);
        UserEmpresa BuscarPorId(Guid id);
        UserEmpresa BuscarPorNome(string nome);

        ICollection<UserEmpresa> Listar();
    }
}
