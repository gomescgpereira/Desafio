using Flunt.Notifications;
using Flunt.Validations;
using Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.ValuesObject
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail("address", "email.address", "e-mail inválido")
                .IsEmailOrEmpty("address", "email.address", "e-mail inválido")
                );

        }

        public string Address { get; private set; }
    }
}
