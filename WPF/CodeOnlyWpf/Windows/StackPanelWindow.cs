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
            border.CornerRadius = new CornerRadius(10);

            var stackPanel = new StackPanel();
            border.Child = stackPanel;

            var expander = new Expander();
            expander.IsExpanded = true;
            expander.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 255));
            expander.Header = "Label show here.";
            var label = new Label();
            label.Content = "Test Panel Target";
            expander.Content = label;

            var button1 = new Button();
            button1.Content = "button1";
            button1.MinHeight = 100;
            button1.MinWidth = 200;

            var buttonBorder = new Border();
            buttonBorder.CornerRadius = new CornerRadius(50);
            buttonBorder.BorderThickness = new Thickness(30);
            var button2 = new Button();
            button2.Content = "button2";
            buttonBorder.Child = button2;

            var button3 = new Button();
            button3.Content = "button3";
            button3.ToolTip = "TESTSTSTS";

            var textBlock = new TextBlock();
            textBlock.MinWidth = 200;
            textBlock.Height = 30;
            textBlock.TextWrapping = TextWrapping.NoWrap;
            textBlock.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            textBlock.Text = "HAHHAHAHAHAfasdf45fdsaf12f21f2a1f21a3 4" +
                             "5asfd5ffdsafdsdsH";

            stackPanel.Children.Add(expander);
            stackPanel.Children.Add(button1);
            stackPanel.Children.Add(buttonBorder);
            stackPanel.Children.Add(button3);
            stackPanel.Children.Add(textBlock);

            stackPanel.AddHandler(ButtonBase.ClickEvent,
                new RoutedEventHandler((sender, e) => MessageBox.Show(e + " Hello,World.")));
            //stackPanel.AddHandler(Label.MouseDownEvent, new RoutedEventHandler((sender, e) =>
            //{
            //    MessageBox.Show("Label Mouse Down" + e);
            //}));


            scrollView.Content = border;

            Content = scrollView;
        }
    }
}
