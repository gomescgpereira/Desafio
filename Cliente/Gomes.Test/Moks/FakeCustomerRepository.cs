using Domain.Context.Entities;
using Domain.Context.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomes.Test.Moks
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Client ConsultarCPF(string document)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExist(string document)
        {
            if (document == "99999999999")
                return true;
            return false;
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
