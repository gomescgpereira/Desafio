using Flunt.Notifications;
using Shared.Context.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Context.Entities;

namespace Domain.Context.Commands
{
    public class CreateClientCommand: Notifiable, ICommand
    {
        public CreateClientCommand(string firstName, string lastName, string documento, string sigla, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Documento = documento;
            Sigla = sigla;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get;  set; }

        public string Documento { get;  set; }

        public string Sigla { get; set; }

        public string Address { get; set; }

        public void Validate()
        {
            
        }
    }
}
