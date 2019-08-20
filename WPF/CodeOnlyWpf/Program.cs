using System;
using System.Configuration;
using System.Windows;

namespace WpfMvvm
{
    public class Program : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Program app = new Program();
            app.MainWindow = new CodeWindow();
            app.MainWindow.ShowDialog();
        }
    }
}