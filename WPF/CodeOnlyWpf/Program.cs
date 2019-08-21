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
            //Program app = new Program();
            //app.MainWindow = new DockPanelWindow();
            //app.MainWindow.ShowDialog();

            // 和上面结果一样
            Application app = new Application();
            var windows = new DockPanelWindow();
            app.Run(windows);
        }
    }
}
