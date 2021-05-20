using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IUsuarioRecrutadoRepository
    {
        void Adicionar(Recrutado usuario);
        void AlterarSenha(Recrutado usuario);
        void Alterar(Recrutado usuario);
        Recrutado BuscarPorEmail(string email);
        Recrutado BuscarPorCPF(string cPF);
        Recrutado BuscarPorId(Guid id);
        Recrutado BuscarPorNome(string nome);

        ICollection<Recrutado> Listar();
    }
}
