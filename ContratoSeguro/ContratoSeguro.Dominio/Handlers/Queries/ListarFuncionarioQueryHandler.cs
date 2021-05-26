using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContratoSeguro.Dominio.Queries.ListarFuncionarioQuery;

namespace ContratoSeguro.Dominio.Handlers.Queries
{
    public class ListarFuncionarioQueryHandler : IHandlerQuery<ListarFuncionarioQuery>
    {
        private readonly IUsuarioFuncionarioRepository _funcionarioRepository;
        public ListarFuncionarioQueryHandler(IUsuarioFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        public IQueryResult Handle(ListarFuncionarioQuery query)
        {
            var funcionario = _funcionarioRepository.Listar();

            var Funcionarios = funcionario.Select(
                x =>
                {
                    return new ListarFuncionariosQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                    };
                }
            );
            return new GenericQueryResult(true, "Lista de Recrutados", Funcionarios);
        }
    }
}
