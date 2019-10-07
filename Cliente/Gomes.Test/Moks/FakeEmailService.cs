using Domain.Context.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomes.Test.Moks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            
        }
    }
}
