using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Repositories;
using System.Linq;
using static ContratoSeguro.Dominio.Queries.BuscarPorNomeRecrutadoQuery;


namespace ContratoSeguro.Dominio.Handlers.Queries
{
    public class BuscarRecrutadoPorNomeQueryHandler : IHandlerQuery<BuscarPorNomeRecrutadoQuery>
    {
        private readonly IRecrutadoRepository _recrutadoRepository;
        public BuscarRecrutadoPorNomeQueryHandler(IRecrutadoRepository recrutadoRepository)
        {
            _recrutadoRepository = recrutadoRepository;
        }

        public IQueryResult Handle(BuscarPorNomeRecrutadoQuery query)
        {
            var recrutado = _recrutadoRepository.BuscarPorNome(query.Nome);

            if (recrutado == null)
                return new GenericQueryResult(false, "Recrutado não encontrado", null);

            var Recrutados = new BuscarPorNomeRecrutadoQueryResult
            {
                Id = recrutado.Id,
                Nome = recrutado.Nome
            };

            return new GenericQueryResult(true, "Recrutados encontrados", Recrutados);

        }
    }
}
