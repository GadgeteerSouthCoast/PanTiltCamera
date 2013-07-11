using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Interfaces;

namespace RemoteCamera
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            joystick.JoystickPressed += new GTM.GHIElectronics.Joystick.JoystickEventHandler(joystick_JoystickPressed);
            button.ButtonPressed += new GTM.GHIElectronics.Button.ButtonEventHandler(button_ButtonPressed);
            GT.Timer timer = new GT.Timer(100);
            timer.Tick += new GT.Timer.TickEventHandler(timer_Tick);
            timer.Start();
        }

        void button_ButtonPressed(GTM.GHIElectronics.Button sender, GTM.GHIElectronics.Button.ButtonState state)
        {
            SendCommand("P", 0, 100);
        }

        void joystick_JoystickPressed(GTM.GHIElectronics.Joystick sender, GTM.GHIElectronics.Joystick.JoystickState state)
        {
            SendCommand("C", 0, 80);
        }

        void timer_Tick(GT.Timer timer)
        {

            display_T35.SimpleGraphics.Clear();
            var position = joystick.GetJoystickPosition();
            if (position.X < .3)
            {
                SendCommand("D", 0, 0);
            }
            else if (position.X > .7)
            {
                SendCommand("U", 0, 20);
            }

            if (position.Y < .3)
            {
                SendCommand("R", 0, 40);
            }
            else if (position.Y > .7)
            {
                SendCommand("L", 0, 60);
            }
        }

        private void SendCommand(string command, int x, int y)
        {
            display_T35.SimpleGraphics.DisplayText(command, Resources.GetFont(Resources.FontResources.small), Colors.Blue, (uint)x, (uint)y);
            rfPipe.SendData(command);
        }
    }
}
