using Domain.Context.Entities;
using Domain.Context.Repository;
using Domain.Context.ValuesObject;
using Gomes.Infra.Contexto.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Repository.Contexto.Entities
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  Client Add(Client cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            
            return cliente;
            
        }

        


        public bool ChecarCPF(string number)
        {
            return _context.Clientes.Where(
              p => p.CPF == number).Count() > 0;
        }

        public Client ConsultarCPF(string number)
        {
            string Nome = "Carlos" +" "+ "Gomes";
            string Documento = "840.280.927-87";
            string estado = ("RJ");
            string email = "gomes@gmail.com";
            Client cli = new Client(Nome, Documento,estado, email );
            return cli;
        }

        public Client Get(int id)
        {

            return  _context.Clientes.Where(
           p => p.Id == id).FirstOrDefault();
            //Client cli = new Client("Carlos","","","");


        }

        public IEnumerable<Client> GetAll()
        {

            return  _context.Clientes.ToList();
        }

       
    }
}
