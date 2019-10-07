using Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context.Repository
{
    public interface ICustomerRepository
    {
        bool  DocumentExist(string document);
        void Save(Client client);
        Client ConsultarCPF(string document);
        IEnumerable<Client> GetAll();
        Client Get(int id);
    }
}
