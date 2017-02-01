using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public class MyEmailClient : IEmailClient
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public IEmailService EmailService { get; set; }

        public void TryToSendEmail(string to, string header, string body)
        {
            // "David" <david@mail.com>
            if (string.IsNullOrEmpty(to) || string.IsNullOrEmpty(header)
                || string.IsNullOrEmpty(body))
                throw new Exception();
            EmailService.SendEmail(to, Name + " <" + Email + ">",
                header, body);
        }
    }
}
