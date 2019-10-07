using Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.ValuesObject
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            if (string.IsNullOrEmpty(FirstName))
              AddNotification(FirstName, "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }


    }

   
}
