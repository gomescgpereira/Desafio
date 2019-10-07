//using Domain.Context.ValuesObject;
using Newtonsoft.Json;
using Shared.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.Entities
{
    public class Client // : Entity
    {
        public Client(string nome, string cPF, string estado, string email)
        {

            Nome = nome;
            CPF = cPF;
            Estado = estado;
            Email = email;
        }

        public int Id { get; private set; }
        [JsonProperty("nome")]
        public string Nome { get; private set; }
        [JsonProperty("cpf")]
        public string CPF { get; private set; }
        [JsonProperty("estado")]
        public string Estado { get; private set; }
        [JsonProperty("email")]
        public string Email { get; private set; }

    }
}