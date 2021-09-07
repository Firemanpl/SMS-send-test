using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS_send_test
{
    class Program
    {
        static void Main(string[] args)
        {
            SendSms send = new SendSms();
            Random random = new Random();
            SMSDto newSms =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddSmsToQueue(newSms);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms1 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddSmsToQueue(newSms1);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms2 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddSmsToQueue(newSms2);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms3 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddSmsToQueue(newSms3);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            Console.Read();
            SMSDto newSms4 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddSmsToQueue(newSms4);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
        }
    }
}