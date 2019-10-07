using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gomes.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Gomes.Domain.Context.Entity;

namespace Gomes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly BillingRepository _repository;

        public BillingController()
        {
            _repository = new BillingRepository();
        }
        
         [HttpGet]
        public async Task<IEnumerable<Billing>> Get()
        {
            return await _repository.GetAll();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Billing> Get(int id)
         {
           return await _repository.GetMonth(id);
        }

        
        
        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Billing value)
        {
             await _repository.InsertUser(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id)
        {
            return await _repository.GetTotal(id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}    