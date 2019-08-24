using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace CodeOnlyWpf.Windows
{
    public class CodeWithXamlWindow : Window
    {
        private Button _button;

        public CodeWithXamlWindow()
        {
            //InitializeComponent();
        }

        public CodeWithXamlWindow(string xamlFile)
        {
            this.Width = this.Height = 300;
            this.Left = this.Top = 100;
            this.Title = "Dynamically Load XAML";

            DependencyObject rootElement;

            using (var fs = new FileStream(xamlFile, FileMode.Open))
            {
                rootElement = XamlReader.Load(fs) as DependencyObject;
            }

            this.Content = rootElement;

            _button = LogicalTreeHelper.FindLogicalNode(rootElement, "button1") as Button;

            // The same as head line;
            //var frameworkElement = rootElement as FrameworkElement;
            //_button = frameworkElement?.FindName("button1") as Button;

            if (_button != null)
            {
                _button.Click += (sender, eventArgs) =>
                {
                    _button.Content = "Happy Good Day.";
                };
            }
        }
    }
}
