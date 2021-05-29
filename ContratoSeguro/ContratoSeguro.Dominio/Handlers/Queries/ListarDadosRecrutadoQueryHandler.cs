using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContratoSeguro.Dominio.Queries.ListarDadosRecrutadoQuery;

namespace ContratoSeguro.Dominio.Handlers.Queries
{
    public class ListarDadosRecrutadoQueryHandler : IHandlerQuery<ListarDadosRecrutadoQuery>
    {

        private readonly IRecrutadoRepository _recrutadoRepository;
        public ListarDadosRecrutadoQueryHandler(IRecrutadoRepository recrutadoRepository)
        {
            _recrutadoRepository = recrutadoRepository;
        }
        public IQueryResult Handle(ListarDadosRecrutadoQuery query)
        {
            var empresa = _recrutadoRepository.BuscarPorId(query.IdRecrutado);

            if (empresa == null)
                return new GenericQueryResult(false, "Recrutado não encontrada ", null);

            var retorno = new ListarDadosRecrutadoQueryResult()
            {
                Nome = empresa.Nome,
                Email = empresa.Email,
                Telefone = empresa.Telefone,
                CPF = empresa.CPF,
            };

            return new GenericQueryResult(true, "Dados do recrutado", retorno);
        }

    }
}
