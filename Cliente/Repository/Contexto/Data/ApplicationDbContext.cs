using Domain.Context.Commands;
using Domain.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomes.Infra.Contexto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
           base(options)
        { }

        public DbSet<Client> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(p => p.Id);

        }
    }
}
