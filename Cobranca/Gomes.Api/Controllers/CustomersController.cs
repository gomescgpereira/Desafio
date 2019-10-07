using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gomes.Domain.Context.Entity;
using Gomes.Domain.Context.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gomes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _repository.GetAll();

        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await _repository.InsertUser(value);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
