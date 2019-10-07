using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
//using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq;
using Gomes.Shared;
using Gomes.Domain.Context.Repository;
using Gomes.Domain.Context.Entity;

namespace Gomes.Repository.Context 
{
    public class BillingRepository : IRepositoryBilling
    {
        private readonly IMongoCollection<Billing> _categories;
        
          
        public BillingRepository()
        {
            var client = new MongoClient(Settings.ConnectionString);
            var database = client.GetDatabase(Settings.Database);
            _categories = database.GetCollection<Billing>("categories");
          //  contatosLista = database.GetCollection<Billing>("categories");

        }
       

        public Task Add(Billing model)
        {
            throw new NotImplementedException();
        }

        public async Task InsertUser(Billing model)
        {
            await _categories.InsertOneAsync(model);
        }

        public async Task<IEnumerable<Billing>> GetAll()
        {
            return await _categories.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<int> GetTotal(int mes)
        {
             var start = new DateTime(2019, mes, 01);
             var end = new DateTime(2019, (mes+1), 01);

            // var result = collection.AsQueryable<Billing>()
            //     .Where(c => c.Valor > 0)
            //     .OrderBy(c => c.Vencimento)
            //     .Count(c => c.CPF);





            return await (from e in _categories.AsQueryable()
                           where e.Valor > 0
                           select e).CountAsync();
        }

        public async Task<Billing> GetMonth(int mes)
        {
            string ano = "09";
            //x => x.Title.Contains("s");
            //var filter = Builders<Billing>.Filter.Eq(x => (x.Vencimento.AsString).Contains(ano));
            //var filter = Builders<Billing>.Filter.Eq({});
            var filterBuilder = Builders<Billing>.Filter;
             var start = new DateTime(2019, mes, 01);
             var end = new DateTime(2019, mes, 30);
             var filter = filterBuilder.Gte(x => x.Vencimento, new BsonDateTime(start)) & filterBuilder.Lte(x => x.Vencimento, new BsonDateTime(end));
            // /var filter = filterBuilder.Ne(x => x.Vencimento, new BsonDateTime(start)) & filterBuilder.Lte(x => x.Vencimento, new BsonDateTime(end));
            //var query = _categories.AsQueryable<Billing>.EQ(p => p.Vencimento.getMonth(), mes);
            //  var query = from e in _categories.AsQueryable<Billing>()
            //            where (e.Vencimento).Month > 0
            //           select e;
           //return await query.FirstOrDefaultAsync();             
           //return await _categories.Find({ }).FirstOrDefaultAsync();
           return await _categories.Find(filter).FirstOrDefaultAsync();
        }

         public Task<Billing> Get(string name)
         {
             throw new NotImplementedException();
         }


        public Task<Billing> Remove(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpDate(Billing model)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Billing>> IRepositoryBilling.GetAll()
        {
            throw new NotImplementedException();
        }

        
    }


}