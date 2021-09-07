using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMS_send_test
{
    public class SendSmsClass
    {
        private readonly string[] _ports;
        private readonly Queue<SMSDto> _queue = new();
        private readonly SerialPort _serialPort;

        public SendSmsClass()
        {
            var serialPort = new SerialPort();
            var ports = SerialPort.GetPortNames();
            Console.WriteLine("Serial Ports: ");
            var count = 0;
            foreach (var port in ports)
            {
                count++;
                Console.WriteLine(count + ". " + port);
            }
            var exist = ports.Contains("/dev/ttyUSB0");
            if (!exist) throw new NotImplementedException("Modem 3G/4G is not plugged into usb.");
            _serialPort = serialPort;
            _ports = ports;
            SendSms();
        }

        public void AddToQueue(SMSDto dto)
        {
            _queue.Enqueue(dto);
            Console.WriteLine(_queue.Count);
        }

        private void SendSms()
        { 
            Task.Run(async() =>
            {
                while (true)
                {
                    if (_queue.Count > 0)
                    {
                        var dto = _queue.Dequeue();
                        Console.WriteLine(dto.Nationality);
                        Console.WriteLine(dto.PhoneNumber);
                        Console.WriteLine(dto.VerificationCode.Insert(4, "-")); 
                        await Task.Delay(1000);
                    }


                }
                // _serialPort.PortName = _ports.LastOrDefault();
                // _serialPort.BaudRate = 9600;
                // _serialPort.ReadTimeout = 500;
                // _serialPort.WriteTimeout = 500;
                // _serialPort.Open();
                // if (_serialPort.IsOpen)
                // {
                //     _serialPort.WriteLine("AT+CMGF = 1");
                //     await Task.Delay(100);
                //     _serialPort.Write("AT+CMGS=\"" + dto.PhoneNumber + "\"\r\n");
                //     await Task.Delay(100);
                //     _serialPort.Write("Your verification code: " + dto.VerificationCode.Insert(4," - ") + "\x1A");
                //     Console.WriteLine(_serialPort.ReadExisting());
                //     _serialPort.Close();
                // }
            });
    }
    }
}