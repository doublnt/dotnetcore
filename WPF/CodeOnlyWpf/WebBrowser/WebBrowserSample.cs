using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeOnlyWpf.WebBrowser
{
    public class WebBrowserSample : Window
    {
        private System.Windows.Controls.WebBrowser _currentWebBrowser = new System.Windows.Controls.WebBrowser();

        public WebBrowserSample()
        {
            InitializeComponent();
            _currentWebBrowser.Navigate(new Uri("https://www.baidu.com"));
        }

        private void InitializeComponent()
        {
            this.Height = this.Width = 400;
            this.Left = this.Top = 400;
            this.Title = "WebBrowser Sample";

            var dockPanel = new DockPanel();

            #region Configure WebBrowser

            _currentWebBrowser.Navigating += (sender, e) =>
            {
                if (e.Uri.Host.EndsWith(".icon") | e.Uri.Host.EndsWith(".ico"))
                {
                    MessageBox.Show("Icon shows");
                }
            };

            _currentWebBrowser.Height = 300;

            _currentWebBrowser.Cursor = Cursors.Arrow;
            #endregion

            var button = new Button();
            button.Content = "Icon Navigate";
            button.Click += (sender, e) =>
            {
                _currentWebBrowser.Navigate("https://www.baidu.com/favicon.ico");
            };

            DockPanel.SetDock(_currentWebBrowser, Dock.Top);
            DockPanel.SetDock(button, Dock.Bottom);

            dockPanel.Children.Add(_currentWebBrowser);
            dockPanel.Children.Add(button);

            this.Content = dockPanel;
        }
    }
}
