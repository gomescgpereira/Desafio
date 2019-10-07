using Gomes.Dominio.Contexto.Entidades;
using Gomes.Dominio.Contexto.Repositorio;
using Gomes.Infra.Contexto.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomes.Infra.Contexto.Repositorio
{
    public class RepositorioCliente: IClienteRepositorio
    {
        private ApplicationDbContext _context;

        public RepositorioCliente(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cliente Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public bool ChecarCPF(string document)
        {
            return _context.Clientes.AsNoTracking().Where(
              p => p.CPF == document).Count() > 0;

        }

        public async Task<Cliente> ConsultarCPF(string document)
        {
            return await _context.Clientes.AsNoTracking().Where(
            p => p.CPF == document).FirstOrDefaultAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.AsNoTracking().Where(
            p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
    }
}
