using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeOnlyWpf.Windows
{
    public class DockPanelWindow : Window
    {
        private TextBlock _textBlock = new TextBlock() { Height = 50 };

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

            var buttonTop = new Button() { Height = 50 };
            buttonTop.Content = "ButtonTop";
            DockPanel.SetDock(buttonTop, Dock.Top);

            var buttonBottom = new Button() { Height = 50 };
            buttonBottom.Content = "ButtonBottom";
            DockPanel.SetDock(buttonBottom, Dock.Bottom);

            dockPanel.Children.Add(buttonTop);
            dockPanel.Children.Add(buttonBottom);

            _textBlock.Background = Brushes.Orange;
            DockPanel.SetDock(_textBlock, Dock.Left);
            dockPanel.Children.Add(_textBlock);

            buttonTop.Click += ButtonTop_Click;

            buttonBottom.Click += ButtonBottom_Click;

            this.Content = dockPanel;
        }

        private void ButtonBottom_Click(object sender, RoutedEventArgs e)
        {
            Task delay = AsyncTask();
            delay.Wait();
        }

        private async Task AsyncTask()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            _textBlock.Text = "Async Starting...";
            Task delay = Task.Delay(5000);
            _textBlock.Text += $"Running for {stopWatch.Elapsed.TotalMilliseconds} seconds.";
            await delay;

            _textBlock.Text += $"Running for {stopWatch.Elapsed.TotalMilliseconds} seconds";
        }

        private void ButtonTop_Click(object sender, RoutedEventArgs e)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            _textBlock.Text = "Sync Starting...";
            Thread.Sleep(5000);
            _textBlock.Text += $"Running for {stopWatch.Elapsed.TotalMilliseconds} seconds";
            _textBlock.Text += "Done.";
        }
    }
}
