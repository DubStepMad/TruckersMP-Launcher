using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace tsrvtcnew
{
    class Timer
    {
        public static int Min { get; set; }
        public static int final;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        public static void Calculate()
        {
            if (Form1.calc_check == false)
            {
                int delay = Form1.timeconvert;
                final = delay * 1000;
                Timers();
                return;
            }

            if (Form1.calc_check == true)
            {
                int delay = Form1.timeconvert;
                final = delay * 1000 * Min;
                Timers();
                return;
            }
        }
        public static void Timers()
        {
            Form1.setbusy = true;
            SendKeys.SendWait("y");
            SendKeys.SendWait("{BACKSPACE}");
            SendKeys.SendWait("^v");
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(final);
        }

        public static void Ccpanel_action()
        {
            ccpanel.setbusy = true;
            SendKeys.SendWait("y");
            SendKeys.SendWait("{BACKSPACE}");
            SendKeys.SendWait("^v");
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(15000);
        }
    }
}
