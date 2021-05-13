using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IUsuarioFuncionarioRepository
    {
        void Adicionar(UserFuncionario usuario);
        void AlterarSenha(UserFuncionario usuario);
        void Alterar(UserFuncionario usuario);
        UserFuncionario BuscarPorEmail(string email);
        UserFuncionario BuscarPorCPF(string cPF);
        UserFuncionario BuscarPorId(Guid id);
        UserFuncionario BuscarPorNome(string nome);

        ICollection<UserFuncionario> Listar();
    }
}
