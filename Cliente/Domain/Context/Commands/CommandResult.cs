using Shared.Context.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.Commands
{
    public  class CommandResult  : ICommandResult
    {
        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult()
        { }

        public bool Success { get; set; }
        public string  Message { get; set; }
    }
}
