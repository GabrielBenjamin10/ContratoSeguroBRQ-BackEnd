using ContratoSeguro.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContratoSeguro.Comum.Handlers
{
    interface IHandlerQuery<T> where T : ICommand
    {
    }
}
