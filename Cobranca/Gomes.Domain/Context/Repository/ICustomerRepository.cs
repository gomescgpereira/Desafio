using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Gomes.Domain.Context.Entity;
  

namespace Gomes.Domain.Context.Repository
{
  public interface ICustomerRepository
  {
      Task<IEnumerable<Customer>> GetAll();
      Task<Customer> Get(string name);
      Task Add(Customer model);
      Task InsertUser(Customer command);
  }
}    