using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

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

            var wrapPanel = new WrapPanel();

            var button = new Button() { Content = "Test" };
            wrapPanel.Children.Add(button);
            var button2 = new Button() { Content = "111" };
            wrapPanel.Children.Add(button2);

            button.Click += Button_Click;
            border.Child = wrapPanel;
            scrollView.Content = border;

            Content = scrollView;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Cause deadlock
            // var value = GetContent().Result;

            var value = await GetContent();
            var button = sender as Button;

            if (button != null)
            {
                button.Content = value.Length;
            }
        }

        private async Task<string> GetContent()
        {
            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync("http://www.baidu.com"))
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
