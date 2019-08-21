using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfMvvm
{
    public class StackPanelWindow : Window
    {
        public StackPanelWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Height = this.Width = 300;
            this.Top = this.Left = 300;
            this.Title = "Test Stack Panel";

            var border = new Border();
            border.CornerRadius = new CornerRadius(10);

            var stackPanel = new StackPanel();
            border.Child = stackPanel;

            var label = new Label();
            label.Content = "Test Panel Target";

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

            stackPanel.Children.Add(label);
            stackPanel.Children.Add(button1);
            stackPanel.Children.Add(buttonBorder);
            stackPanel.Children.Add(button3);

            stackPanel.AddHandler(Button.ClickEvent,
                new RoutedEventHandler((sender, e) => MessageBox.Show(e + " Hello,World.")));
            stackPanel.AddHandler(Label.MouseDownEvent, new RoutedEventHandler((sender, e) =>
            {
                MessageBox.Show("Label Mouse Down" + e);
            }));


            this.Content = border;
        }
    }
}
