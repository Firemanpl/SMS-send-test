using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMS_send_test
{
    public class SendSms
    {
        private readonly string[] _ports;
        private readonly Queue<SMSDto> _queue = new();
        private readonly SerialPort _serialPort;

        public SendSms()
        {
            var serialPort = new SerialPort();
            var ports = SerialPort.GetPortNames();
            Console.WriteLine("Serial Ports: ");
            for (int i=0;i<ports.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + ports[i]);
            }
            var exist = ports.Contains("/dev/ttyUSB0");
            if (!exist) throw new NotImplementedException("Modem 3G/4G is not plugged into usb.");
            _serialPort = serialPort;
            _ports = ports;

            SendAsync();
        }

        ~SendSms()
        {
            
        }
        public void AddSmsToQueue(SMSDto dto)
        {
            _queue.Enqueue(dto);
            Console.WriteLine(_queue.Count);
        }

        private async Task SendAsync()
        { 
            await Task.Run(async() =>
            {
                while (true)
                {
                    if (_queue.Count > 0)
                    {
                        var dto = _queue.Dequeue();
                        if (dto.VerificationCode.Length > 160)
                        {
                            return false;
                        }
                        _serialPort.PortName = _ports.LastOrDefault();
                        _serialPort.BaudRate = 9600;
                        _serialPort.ReadTimeout = 500;
                        _serialPort.WriteTimeout = 500;
                        _serialPort.Open();
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.WriteLine("AT+CMGF = 1");
                            await Task.Delay(3000);
                            _serialPort.Write("AT+CMGS=\"" + dto.PhoneNumber + "\"\r\n");
                            await Task.Delay(1000);
                            _serialPort.Write("Your verification code: " + dto.VerificationCode.Insert(4,"-") + "\x1A");
                            var result = _serialPort.ReadExisting();
                            Console.WriteLine(result);
                            if (result.Contains("ERROR"))
                                Console.WriteLine("Something went wrong!");
                            //await Task.Delay(2000);
                            _serialPort.Close();
                        }
                    }
                }
            });
    }
    }
}