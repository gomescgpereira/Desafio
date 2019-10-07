using Shared.Context.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Context.Handlers
{
    public interface IHandler<T> where T: ICommand 
    {
        ICommandResult Handler(T command);
    }
}
