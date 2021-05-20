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
        void Adicionar(Funcionario usuario);
        void AlterarSenha(Funcionario usuario);
        void Alterar(Funcionario usuario);
        Funcionario BuscarPorEmail(string email);
        Funcionario BuscarPorCPF(string cPF);
        Funcionario BuscarPorId(Guid id);
        Funcionario BuscarPorNome(string nome);

        ICollection<Funcionario> Listar();
    }
}
