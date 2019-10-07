
using Domain.Context.Entities;
using Domain.Context.ValuesObject;
using Domain.Context.Handlers;
using System;
using Xunit;
using Gomes.Test.Moks;
using Domain.Context.Commands;

namespace Gomes.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnComnandExist()
        {
            var command = new CreateClientCommand("", "Pereira","84028092788","RJ","gomes@gmail.com");
            //command.FirstName = "";
            command.Validate();
            Assert.True(command.Valid);
            // Assert.Equals(true, command.Valid);
                
        }
       //[Fact]
        // public void ShouldReturnHandler()
        // {
        //     var handler = new ClientHandler(new FakeCustomerRepository() , new FakeEmailService());
        //     var command = new CreateClientCommand(); ;

        //     command.FirstName = "Carlos";
        //     command.LastName = "Gomes";
        //     command.Documento = "84028092787";
        //     command.Address = "gomes@gmail.com";
        //     command.Sigla = "SP";
        //     handler.Handler(command);


            
        //      Assert.True(handler.Valid);

        // }

        [Fact]
        public void ShouldReturnErrorWhenCPFInvalid()
        {
            var doc = new Document("123");
            Assert.False(doc.Valid);
            
            
        }

        [Fact]
        public void ShouldReturnSuccessWhenCPFValid()
        {
            var doc = new Document("840.280.927-87");
            Assert.True(doc.Valid);



        }

        [Fact]
        public void ShouldReturnErrorWhenClientInvalid()
        {
            Name Nome = new Name("Carlos", "Gomes");
            Document doc = new Document("123");
            Estado estado = new Estado("RJ");
            Email email = new Email("gomes@gmail.com");
            Client cli = new Client(Nome, doc, estado, email);
            Assert.False(cli.Valid);



        }

        [Fact]
        public void ShouldReturnSuccessWhenClientValid()
        {
            Name Nome = new Name("Carlos", "Gomes");
            Document Documento = new Document("840.280.927-87");
            Estado estado = new Estado("RJ");
            Email email = new Email("gomes@gmail.com");
            Client cli = new Client(Nome, Documento, estado, email);


            Assert.True(cli.Valid);



        }

    }
}
