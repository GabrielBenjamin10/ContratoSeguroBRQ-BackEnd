using Classificados.Comum.Util;
using ContratoSeguro.Comum.Commands;
using ContratoSeguro.Comum.Handlers;
using ContratoSeguro.Dominio.Commands.Usuarios;
using ContratoSeguro.Dominio.Entidades;
using ContratoSeguro.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratoSeguro.Dominio.Handlers.Command.Usuario
{
    public class CriarContaEmpresaCommandHandler : Notifiable, IHandlerCommand<CriarContaEmpresaCommand>
    {
        private readonly IUsuarioEmpresaRepository _usuarioEmpresaRepositorio;
        public CriarContaEmpresaCommandHandler(IUsuarioEmpresaRepository usuarioEmpresaRepositorio)
        {
            _usuarioEmpresaRepositorio = usuarioEmpresaRepositorio;
        }

        public ICommandResult Handle(CriarContaEmpresaCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do usuário Inválidos", command.Notifications);

            //Verifica se cpf existe
            var cpfExiste = _usuarioEmpresaRepositorio.BuscarPorCNPJ(command.CNPJ);
            if (cpfExiste != null)
                return new GenericCommandResult(false, "CNPJ já cadastrado", null);

            //Verifica se email existe
            var usuarioExiste = _usuarioEmpresaRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //Criptografar Senha 
            command.Senha = Senha.Criptografar(command.Senha);

            //Salvar Usuário
            var usuario = new Entidades.UserEmpresa(command.Nome, command.Email, command.Senha, command.TipoUsuario, command.CNPJ, command.RazaoSocial,command.Matriz, command.Logradouro, command.UF, command.Cidade, command.Numero, command.Bairro, command.DataAbertura);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications);

            _usuarioEmpresaRepositorio.Adicionar(usuario);

            //Enviar Email de Boas Vindas
            //Send Grid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
