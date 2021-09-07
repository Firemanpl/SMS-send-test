using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS_send_test
{
    class Program
    {
        static void Main(string[] args)
        {
            SendSmsClass send = new SendSmsClass();
            Random random = new Random();
            SMSDto newSms =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddToQueueSms(newSms);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms1 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddToQueueSms(newSms1);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms2 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddToQueueSms(newSms2);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms3 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddToQueueSms(newSms3);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            Console.Read();
            SMSDto newSms4 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            send.AddToQueueSms(newSms4);
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
        }
    }
}