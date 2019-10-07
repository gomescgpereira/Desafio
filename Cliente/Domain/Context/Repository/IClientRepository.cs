using Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.Repository
{
    public interface IClientRepository
    {
        bool ChecarCPF(string number);
        Client Add(Client cliente);
        Client ConsultarCPF(string number);
        
       
       
       
        IEnumerable<Client> GetAll();
        Client Get(int id);
       
       
    }
}
