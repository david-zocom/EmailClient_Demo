using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public interface IEmailService
    {
        void SendEmail(string to, string from,
            string header, string body);
    }
}
