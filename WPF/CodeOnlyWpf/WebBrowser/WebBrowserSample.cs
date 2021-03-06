﻿using System;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

using SHDocVw;

namespace CodeOnlyWpf.WebBrowser
{
    public class WebBrowserSample : Window
    {
        private System.Windows.Controls.WebBrowser _currentWebBrowser = new System.Windows.Controls.WebBrowser();
        private SHDocVw.IWebBrowser2 _iWebBrowser2;

        private Label _currentLabel = new Label() { Height = 20 };

        public WebBrowserSample()
        {
            InitializeComponent();
        }

        public SHDocVw.IWebBrowser2 WebBrowser2
        {
            get
            {
                if (_iWebBrowser2 == null)
                {
                    var args = new Object[] { };
                    _iWebBrowser2 = (SHDocVw.IWebBrowser2)(_currentWebBrowser.GetType().InvokeMember("AxIWebBrowser2",
                        BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        _currentWebBrowser, args));
                }
                return _iWebBrowser2;
            }
        }

        private void HandleBeforeNavigate(string url, int flags, string targetName, ref object postData, string header,
            ref bool Cancel)
        {
            MessageBox.Show(url);
        }

        private void HandleNewWindow(string url, int flags, string targetName, ref object postData, string header,
            ref bool Cancel)
        {
            MessageBox.Show(url);
        }

        private void InitializeComponent()
        {
            this.Height = this.Width = 400;
            this.Left = this.Top = 400;
            this.Title = "WebBrowser Sample";

            var dockPanel = new DockPanel();

            #region Configure WebBrowser

            if (WebBrowser2 != null)
            {
                ((SHDocVw.DWebBrowserEvents_Event)_iWebBrowser2).BeforeNavigate += HandleBeforeNavigate;
                ((SHDocVw.DWebBrowserEvents_Event)_iWebBrowser2).NewWindow += HandleNewWindow;
            }

            _currentWebBrowser.Height = 300;

            _currentWebBrowser.Cursor = Cursors.Arrow;
            #endregion

            var button = new Button();
            button.Content = "Icon Navigate";

            DockPanel.SetDock(_currentWebBrowser, Dock.Top);
            DockPanel.SetDock(button, Dock.Bottom);

            dockPanel.Children.Add(_currentWebBrowser);
            dockPanel.Children.Add(button);

            _currentWebBrowser.Navigate(new Uri("http://localhost:5000"));

            this.Content = dockPanel;


            Func<string> a = delegate
            {
                return "10086";
            };
        }
    }
}
