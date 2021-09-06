using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS_send_test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SendSmsClass send = new SendSmsClass();
            Random random = new Random();
            SMSDto newSms =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            await Task.Run(() => send.AddToQueue(newSms));
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms1 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            await Task.Run(() => send.AddToQueue(newSms1));
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms2 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            await Task.Run(() => send.AddToQueue(newSms2));
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
            SMSDto newSms3 =  new SMSDto()
            {
                Nationality = "+48",
                PhoneNumber = "661368411",
                VerificationCode = random.Next(10000000,99999999).ToString(),
            };
            await Task.Run(() => send.AddToQueue(newSms3));
            Console.WriteLine("Testowa wiadomość wrzucana po wywołaniu metody AddToQueue");
        }
    }
}