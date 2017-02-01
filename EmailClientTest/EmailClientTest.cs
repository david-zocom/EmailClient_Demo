using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EmailClient;
using Moq;

namespace EmailClientTest
{
    public class EmailClientTest
    {
        [Fact]
        public void SendEmail_NoEmailService_Throws()
        {
            string to = "destination", header = "Great opportunity",
                body = "I am the Nigerian finance minister";
            MyEmailClient ec = new MyEmailClient();
            Assert.Throws<NullReferenceException>(() => ec.SendEmail(to,
                 header, body));
        }

        [Fact]
        public void SendEmail_InvalidValues_Throws()
        {
            string to = "destination", header = "Great opportunity",
                body = "I am the Nigerian finance minister";
            MyEmailClient ec = new MyEmailClient();
            //ec.EmailService = new FakeEmailService();
            var mock = new Mock<IEmailService>();

            Assert.Throws<Exception>(() => ec.SendEmail(null,
                header, body));
            Assert.Throws<Exception>(() => ec.SendEmail(to,
                null, body));
            Assert.Throws<Exception>(() => ec.SendEmail(to,
                header, null));
            // TODO: test empty strings as well
        }
        /*public int add(int x, int y)
        {
            return x + y;
            throw new OverflowException
        }*/

        [Fact]
        public void SendEmail_CorrectValues_Success()
        {
            string to = "destination", header = "Great opportunity",
                body = "I am the Nigerian finance minister";
            MyEmailClient ec = new MyEmailClient();
            ec.Name = "Antonio";
            ec.Email = "email@emial.com";
            var mock = new Mock<IEmailService>();
            ec.EmailService = mock.Object;
            //FakeEmailService fake = new FakeEmailService();
            //ec.EmailService = fake;
            ec.SendEmail(to, header, body);
            string from = ec.Name + " <" + ec.Email + ">";
            mock.Verify(x => x.SendEmail(to, from, 
                header, body),
                Times.Once());
           // Assert.Equal(1, fake.HowManyTimesHasSendEmailBeenCalled);
        }

    }
    /*class FakeEmailService : IEmailService
    {
        public int HowManyTimesHasSendEmailBeenCalled { get; set; } = 0;

        public void SendEmail(string to, string from, string header, string body)
        {
            HowManyTimesHasSendEmailBeenCalled++;
            //throw new NotImplementedException();
        }
    }*/
}

