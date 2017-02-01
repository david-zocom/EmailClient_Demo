using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    interface IEmailClient
    {
        void Setup(string myEmail, string myName);

        void SendEmail(string to, string header, string body);
    }
}
