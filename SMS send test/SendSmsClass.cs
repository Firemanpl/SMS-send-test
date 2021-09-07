using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_send_test
{
    public class SendSmsClass
    {
        private static string[] _ports;
        private static readonly Queue<SMSDto> _queue = new();
        private static SerialPort _serialPort;

        public SendSmsClass()
        {
            var serialPort = new SerialPort();
            var ports = SerialPort.GetPortNames();
            Console.WriteLine("Serial Ports: ");
            for (var i = 0; i < ports.Length; i++) Console.WriteLine(i + 1 + ". " + ports[i]);
            var exist = ports.Contains("/dev/ttyUSB0");
            if (!exist) throw new NotImplementedException("Modem 3G/4G is not plugged into usb.");
            _serialPort = serialPort;
            _ports = ports;
        }

        public void AddToQueueSms(SMSDto dto)
        {
            _queue.Enqueue(dto);
            Console.WriteLine(_queue.Count);
        }

        private static async Task SendSms()
        {
            await Task.Run(async () =>
            {
                while (true)
                    if (_queue.Count > 0)
                    {
                        var dto = _queue.Dequeue();
                        _serialPort.PortName = _ports.Contains("/dev/ttyUSB0").ToString();
                        _serialPort.BaudRate = 9600;
                        _serialPort.ReadTimeout = 500;
                        _serialPort.WriteTimeout = 500;
                        _serialPort.Open();
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.WriteLine("AT+CMGF = 1");
                            await Task.Delay(100);
                            _serialPort.Write("AT+CMGS=\"" + dto.PhoneNumber + "\"\r\n");
                            await Task.Delay(100);
                            _serialPort.Write("Your verification code: " + dto.VerificationCode.Insert(4, "-") + "\x1A");
                            var result = _serialPort.ReadExisting();
                            Console.WriteLine(result);
                            if (result.Contains("ERROR"))
                                throw new Exception("Sim card ERROR!"); //this exception will not execute !!!
                            _serialPort.Close();
                        }
                    }
            });
        }
    }
}