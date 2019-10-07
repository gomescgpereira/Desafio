using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context.Services
{
    public interface IEmailService
    {
        void Send(string to, string email, string subject, string body);
    }
}
