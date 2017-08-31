using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace tsrvtcnew
{
    class timer
    {
        public static int min { get; set; }
        public static int final;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        public static void calculate()
        {
            if (Form1.calc_check == false)
            {
                int delay = Form1.timeconvert;
                final = delay * 1000;
                timers();
                return;
            }

            if (Form1.calc_check == true)
            {
                int delay = Form1.timeconvert;
                final = delay * 1000 * min;
                timers();
                return;
            }
        }
        public static void timers()
        {

            Form1.setbusy = true;
            SendKeys.SendWait("y");
            SendKeys.SendWait("{BACKSPACE}");
            SendKeys.SendWait("^v");
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(final);
        }

        public static void ccpanel_action()
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
