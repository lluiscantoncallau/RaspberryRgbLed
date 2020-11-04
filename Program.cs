using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace RaspberryRgbLed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start RGB Led Random";

            Pi.Init<BootstrapWiringPi>();
            const int range = 100;
            var redPin = (GpioPin)Pi.Gpio[BcmPin.Gpio17];
            var greenPin = (GpioPin)Pi.Gpio[BcmPin.Gpio18];
            var bluePin = (GpioPin)Pi.Gpio[BcmPin.Gpio27];

            redPin.PinMode = GpioPinDriveMode.Output;
            redPin.StartSoftPwm(0, range);

            greenPin.PinMode = GpioPinDriveMode.Output;
            greenPin.StartSoftPwm(0, range);

            bluePin.PinMode = GpioPinDriveMode.Output;
            bluePin.StartSoftPwm(0, range);

            var rand = new Random();

            while (true)
            {
                SetRgb(redPin, greenPin, bluePin, rand.Next(0, range), rand.Next(0, range), rand.Next(0, range));
                Thread.Sleep(100);              
            }
        }

        public static void SetRgb(GpioPin redPin, GpioPin greenPin, GpioPin bluePin, int red, int green, int blue)
        {
            redPin.SoftPwmValue = red;
            greenPin.SoftPwmValue = green;
            bluePin.SoftPwmValue = blue;
            Console.Write("R" + red.ToString() + "G " + green.ToString() + "B " + blue.ToString())
        }
    }
}
