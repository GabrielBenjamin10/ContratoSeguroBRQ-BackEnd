using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Comum.Queries;
using ContratoSeguro.Dominio.Queries;
using ContratoSeguro.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContratoSeguro.Dominio.Queries.ListarDadosEmpresaQuery;

namespace ContratoSeguro.Dominio.Handlers.Queries
{
    public class ListarDadosEmpresaQueryHandler :  IHandlerQuery<ListarDadosEmpresaQuery>
    {
        private readonly IEmpresaRepository _empresaRepository;

        public ListarDadosEmpresaQueryHandler(IEmpresaRepository empresaRepository, IUsuarioRepository usuarioRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public IQueryResult Handle(ListarDadosEmpresaQuery query)
        {
            var empresa = _empresaRepository.BuscarPorId(query.IdEmpresa);

            if (empresa == null)
                return new GenericQueryResult(false, "Empresa não encontrada ", null);

            var retorno = new ListarDadosEmpresaQueryResult()
            {
                Nome = empresa.Nome,
                Email = empresa.Email,
                Telefone = empresa.Telefone,
                CNPJ = empresa.CNPJ,
                Matriz = empresa.Matriz,
                UF = empresa.UF,
                Cidade = empresa.Cidade,
                Logradouro = empresa.Logradouro
            };

            return new GenericQueryResult(true, "Dados da empresa", retorno);
        }
    }
}
