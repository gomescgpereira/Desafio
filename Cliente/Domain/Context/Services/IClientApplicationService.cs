using Domain.Context.Commands;
using Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.Services
{
    public interface IClientApplicationService
    {
        IEnumerable<Client> Get();
        Client Get(int id);
        Client Create(CreateClientCommand command);
        void Update(Client client);
        void Delete(Client client);

    }
}
