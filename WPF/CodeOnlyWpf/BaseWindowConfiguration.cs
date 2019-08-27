using System.Windows;

namespace CodeOnlyWpf
{
    public static class BaseWindowConfiguration
    {
        public static void Initialize(Window window)
        {
            window.Height = window.Width = 500;
            window.Left = window.Top = 500;
            window.Title = "Windows Local Test";
        }
    }
}
