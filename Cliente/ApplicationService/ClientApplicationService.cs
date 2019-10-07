
using Domain.Context.Commands;
using Domain.Context.Entities;
using Domain.Context.Repository;
using Domain.Context.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService
{
    public class ClientApplicationService : IClientApplicationService
    {
        private readonly IClientRepository _repository;

        public ClientApplicationService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Client Create(CreateClientCommand command)
        {
            var cliente = new Client(command.FirstName, command.Documento, command.Sigla, command.Address);

            return  _repository.Add(cliente);



        }

        public void Delete(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> Get()
        {
            return _repository.GetAll();
        }

        public Client Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }

       
    }
}
