using ContratoSeguro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratoSeguro.Dominio.Repositories
{
    public interface IRecrutadoRepository
    {
        void Adicionar(Recrutado usuario);
        Recrutado BuscarPorCPF(string cPF);
        Recrutado BuscarPorNome(string nome);
        Recrutado BuscarPorId(Guid id);
        void Alterar(Usuario usuario);

        ICollection<Recrutado> Listar();
    }
}
