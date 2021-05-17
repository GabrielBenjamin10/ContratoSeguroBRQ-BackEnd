using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IUsuarioRecrutadoRepository
    {
        void Adicionar(UserRecrutado usuario);
        void AlterarSenha(UserRecrutado usuario);
        void Alterar(UserRecrutado usuario);
        UserRecrutado BuscarPorEmail(string email);
        UserRecrutado BuscarPorCPF(string cPF);
        UserRecrutado BuscarPorId(Guid id);
        UserRecrutado BuscarPorNome(string nome);

        ICollection<UserRecrutado> Listar();
    }
}
