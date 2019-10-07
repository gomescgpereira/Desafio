using Domain.Context.Commands;
using Domain.Context.Entities;
using Domain.Context.Repository;
using Domain.Context.Services;
using Domain.Context.ValuesObject;
using Flunt.Notifications;
using Shared.Context.Command;
using Shared.Context.Handlers;
using System;

namespace Domain.Context.Handlers
{
    public class ClientHandler : Notifiable, IHandler<CreateClientCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _service;

        public ClientHandler(ICustomerRepository repository, IEmailService service)
        {
            _repository = repository;
            _service = service;
        }

        public ICommandResult Handler(CreateClientCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível cadastrar");
            }
            // Verificar e o CPF já existe

            if (_repository.DocumentExist(command.Documento))
            {
                AddNotification("command.Document", "Este CPF já existe");
            }

            // Gear VOs
            var nome = command.FirstName + command.LastName;
            var documento = command.Documento;
            var estado = command.Sigla;
            var email = command.Address;

            //  Gerar Entidades
            var cliente = new Client(nome, documento, estado,email );

            // Agrupar Notificaços
            //AddNotifications(nome, documento, estado, email);

            if (Invalid)
                 return new CommandResult(false, "Não foi possível cadastrar");
            
            // Salvar Informações
            _repository.Save(cliente);

            // Agradecimentos

            _service.Send(cliente.Nome.ToString(), cliente.Email, "Bem vindo a Consultoria", "Dados cadastrados com sucesso");
            return new CommandResult(true, "Cliente cadastrado com sucesso");
        }
    }
}
