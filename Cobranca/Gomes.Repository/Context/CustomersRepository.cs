using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
//using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Gomes.Shared;
using Gomes.Domain.Context.Repository;
using Gomes.Domain.Context.Entity;

namespace Gomes.Repository.Context 
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;
        

        public CustomerRepository()
        {
            var client = new MongoClient(Settings.ConnectionString);
            var database = client.GetDatabase(Settings.Database);
            _customers = database.GetCollection<Customer>("customers");

        }

        public async Task Add(Customer model)
        {
           throw new NotImplementedException();

        }

        

        public async Task InsertUser(Customer model)
        {
            await _customers.InsertOneAsync(model);
        }        

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customers.Find(new BsonDocument()).ToListAsync();
        }
         
        
       public async Task<Customer> Get(string name)
       {
          throw new NotImplementedException();

       }
      

    }
}   