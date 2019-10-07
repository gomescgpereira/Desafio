using Flunt.Notifications;
using Flunt.Validations;
using Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.ValuesObject
{
    public class Estado : ValueObject
    {
        public Estado(string sigla)
        {
            Sigla = sigla;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty("Sigla", "Estado.Sigla", "Estado inválido")
                .HasMinLen("Sigla", 2, "Estado.Sigla", "Estado inválido")
                );
        }

        public string Sigla { get; private set; }


    }
}
