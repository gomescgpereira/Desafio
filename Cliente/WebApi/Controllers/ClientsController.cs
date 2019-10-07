using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Context.Commands;
using Domain.Context.Entities;
using Domain.Context.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientApplicationService _service;
       
            
        public ClientsController(IClientApplicationService service)
        {
            _service = service;
        }

        // GET: api/Clients

        [HttpGet]

        public IEnumerable<Client> Get()
        {
            return _service.Get();
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "Get")]
        public Client Get(int id)
        {
            return _service.Get(id);
        }

        // POST: api/Clients
        //public Client Post([FromBody] CreateClientCommand body)
        [HttpPost]
        public async Task<Client> Post([FromBody] CreateClientCommand body)
        {
            
           // var command = new  CreateClientCommand(
           //   firstName:  (string)body.first,
           //   lastName:  (string)body.last,
           //   documento:  (string)body.document,
           //   sigla:  (string)body.estado,
           //   address:  (string)body.email
               
           //);

            var cliente = _service.Create(body);
            await  SalvarMongo(cliente);
            return cliente;
        }
        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task SalvarMongo(Client cliente)
        {
            HttpClient client = new HttpClient();
            try
            {
                string url = "http://localhost:5000/api/customers";
                var uri = new Uri(string.Format(url));
                var data = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
