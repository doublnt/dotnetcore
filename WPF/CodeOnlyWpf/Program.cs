using System;
using System.Configuration;
using System.Windows;

using CodeOnlyWpf.WebBrowser;
using CodeOnlyWpf.Windows;

namespace CodeOnlyWpf
{
    public class Program : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //Program app = new Program();
            //app.MainWind  ow = new DockPanelWindow();
            //app.MainWindow.ShowDialog();

            // 和上面结果一样
            var app = new Application();
            var windows = new StackPanelWindow();
            app.Run(windows);
        }
    }
}
