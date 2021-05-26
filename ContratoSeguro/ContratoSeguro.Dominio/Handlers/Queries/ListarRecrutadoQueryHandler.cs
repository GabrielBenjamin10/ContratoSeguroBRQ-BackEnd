using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Repositories;
using System.Linq;
using static ContratoSeguro.Dominio.Queries.ListarRecrutadosQuery;

namespace ContratoSeguro.Dominio.Handlers.Queries.Usuario
{
    public class ListarRecrutadoQueryHandler : IHandlerQuery<ListarRecrutadosQuery>
    {
        private readonly IUsuarioRecrutadoRepository _recrutadoRepository;
        public ListarRecrutadoQueryHandler(IUsuarioRecrutadoRepository recrutadoRepository)
        {
            _recrutadoRepository = recrutadoRepository;
        }

        public IQueryResult Handle(ListarRecrutadosQuery query)
        {
            var recrutado = _recrutadoRepository.Listar();

            var Recrutados = recrutado.Select(
                x =>
                {
                    return new ListarRecrutadosQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        Telefone = x.Telefone
                    };
                }
            );
            return new GenericQueryResult(true, "Lista de Recrutados", Recrutados);
        }
    }
}
