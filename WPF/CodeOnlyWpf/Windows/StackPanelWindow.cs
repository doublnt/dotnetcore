using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace CodeOnlyWpf.Windows
{
    public class StackPanelWindow : Window
    {
        public StackPanelWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Height = Width = 400;
            Top = Left = 300;
            Title = "Test Stack Panel";

            var scrollView = new ScrollViewer();
            var border = new Border();
            var wrapPanel = new StackPanel();

            var button = new Button()
            {
                Content = "Click1"
            };
            wrapPanel.Children.Add(button);

            var button2 = new Button
            {
                Content = "Click2"
            };
            wrapPanel.Children.Add(button2);

            wrapPanel.Children.Add(_textBlock);

            button.Click += Button_Click;
            border.Child = wrapPanel;
            scrollView.Content = border;
            Content = scrollView;
        }

        private TextBlock _textBlock = new TextBlock();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //GetContent().Wait();

            //var a = GetContent().Result;

            _textBlock.Text = Thread.CurrentThread.ManagedThreadId.ToString();

            await GetContent();

            _textBlock.Text = "111";

            SynchronizationContext.Current.Post(_ => { }, null);

            Task.Delay(3000)
                .Run(() => { _textBlock.Text = "222"; });
        }

        private async Task<string> GetContent()
        {
            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync("http://www.baidu.com"))
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                _textBlock.Text = Thread.CurrentThread.ManagedThreadId.ToString();
                return result;
            }
        }

        private Task<bool> GetContentTaskCompletionSourceVersion(Func<bool> func)
        {
            if (null == func)
            {
                throw new ArgumentNullException("action");
            }

            var taskCompletionSource = new TaskCompletionSource<bool>();

            ThreadPool.QueueUserWorkItem(_ =>
             {
                 try
                 {
                     var result = func();

                     taskCompletionSource.SetResult(result);
                 }
                 catch (Exception ex)
                 {
                     taskCompletionSource.SetException(ex);
                 }
             });

            return taskCompletionSource.Task;
        }
    }
}
