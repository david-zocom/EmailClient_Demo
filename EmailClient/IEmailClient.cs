using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public interface IEmailClient
    {
        string Email { get; set; }
        string Name { get; set; }


        void SendEmail(string to, string header, string body);
    }
}
