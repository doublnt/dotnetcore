using System;
using System.Data.Odbc;
using System.Runtime.InteropServices;

namespace CSharpFundamental.InteropServiceCom
{
    public class InteropServicesSample
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        private delegate bool EnumWC(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWC lpEnumWc, IntPtr lParam);

        private static bool OutputWindow(IntPtr hwnd, IntPtr lParam)
        {
            Console.WriteLine(hwnd.ToInt64());

            return true;
        }

        public static void ShowTheOutputWindowResult()
        {
            EnumWindows(OutputWindow, IntPtr.Zero);
        }

        public static void ShowTheMessageBox()
        {
            MessageBox(IntPtr.Zero, "Command-line Message box", "Attention!", 0);
        }
    }
}
