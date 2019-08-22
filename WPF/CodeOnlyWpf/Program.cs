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
            //SplashScreen splashScreen = new SplashScreen("safe_image.gif");
            //splashScreen.Show(false);

            //Program app = new Program();
            //app.MainWind  ow = new DockPanelWindow();
            //app.MainWindow.ShowDialog();

            // 和上面结果一样
            Application app = new Application();
            var windows = new DockPanelWindow();
            app.Run(windows);
        }
    }
}
