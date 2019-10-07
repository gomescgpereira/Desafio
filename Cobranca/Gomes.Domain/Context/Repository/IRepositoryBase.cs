using System;
using System.Collections.Generic;
using System.Threading.Tasks;
  

namespace Gomes.Domain.Context.Repository
{
  public interface IRepositoryBase<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string name);
        Task Add(T model);

        Task UpDate(T model);
        Task<T> RemoveProduct(string name);
        
    } 
  
}