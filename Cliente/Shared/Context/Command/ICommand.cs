using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Context.Command
{
     public interface ICommand
    {
        void Validate();
    }
}
