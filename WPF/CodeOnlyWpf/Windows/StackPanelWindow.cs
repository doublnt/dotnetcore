using System.Net.Http;
using System.Threading;
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
            _textBlock.Text = "111111111";

            wrapPanel.Children.Add(_textBlock);

            button.Click += Button_Click;
            border.Child = wrapPanel;
            scrollView.Content = border;

            Content = scrollView;
        }

        private TextBlock _textBlock = new TextBlock();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await GetContent();
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
