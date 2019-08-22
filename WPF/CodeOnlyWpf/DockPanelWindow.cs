using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfMvvm
{
    public class DockPanelWindow : Window
    {
        public DockPanelWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Width = this.Height = 500;
            this.Left = this.Top = 300;
            this.Title = "Dock panel test";

            var dockPanel = new DockPanel();
            dockPanel.LastChildFill = false;

            var buttonTop = new Button();
            buttonTop.Content = "ButtonTop";
            DockPanel.SetDock(buttonTop, Dock.Top);

            var buttonBottom = new Button();
            buttonBottom.Content = "ButtonBottom";
            DockPanel.SetDock(buttonBottom, Dock.Bottom);

            string textBoxPlaceHolder = "Input text here...";
            var textBox = new TextBox();
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Width = 300;
            textBox.Text = textBoxPlaceHolder;
            textBox.AcceptsReturn = true;
            SpellCheck.SetIsEnabled(textBox, true);
            DockPanel.SetDock(textBox, Dock.Left);

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == textBoxPlaceHolder)
                {
                    textBox.Clear();
                }
            };

            var textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            DockPanel.SetDock(textBlock, Dock.Right);

            textBox.TextChanged += (sender, e) => { textBlock.Text = textBox.Text; };

            dockPanel.Children.Add(buttonTop);
            dockPanel.Children.Add(buttonBottom);
            dockPanel.Children.Add(textBox);
            dockPanel.Children.Add(textBlock);

            //var httpWebRequest = WebRequest.Create("http://10jqka.com.cn/favicon.ico") as HttpWebRequest;
            //var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            var url = "http://10jqka.com.cn";
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(string.Format("http://www.google.com/s2/favicons?domain={0}", url), "favicon.ico");
            }

            this.Content = dockPanel;
        }
    }
}
