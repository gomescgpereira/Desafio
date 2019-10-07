using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gomes.Domain.Context.Entity;
  

namespace Gomes.Domain.Context.Repository
{
  public interface IRepositoryBilling 
  
  {
        Task<IEnumerable<Billing>> GetAll();
        Task<Billing> Get(string name);
        Task Add(Billing model);

        Task UpDate(Billing  model);
        Task<Billing> Remove(string name);

  }
}