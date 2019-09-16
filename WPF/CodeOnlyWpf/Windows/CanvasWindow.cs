using System;
using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CodeOnlyWpf.Windows
{
    public class CanvasWindow : Window
    {
        private Canvas _canvas = new Canvas();

        public CanvasWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var border = CreateRectangle(_canvas, 0, 0);

            this.Content = _canvas;
        }

        private Border CreateRectangle(Canvas currentCanvas, int left, int top)
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Colors.Gray),
                BorderThickness = new Thickness(0),
                CornerRadius = new CornerRadius(5),
                Width = 400,
                Height = 50
            };

            var grid = new Grid();
            var col1 = new ColumnDefinition();
            var col2 = new ColumnDefinition();
            var col3 = new ColumnDefinition();
            var col4 = new ColumnDefinition();
            var row1 = new RowDefinition();

            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions.Add(col3);
            grid.ColumnDefinitions.Add(col4);
            grid.RowDefinitions.Add(row1);

            var securityNameLabel = new Label()
            {
                Content = "原油",
                Foreground = new SolidColorBrush(Colors.Brown),
            };

            var currentPrice = new Label()
            {
                Content = "207.13",
                Foreground = new SolidColorBrush(Colors.Coral)
            };

            var diff = new Label()
            {
                Content = "20.13%",
                Foreground = new SolidColorBrush(Colors.DeepPink)
            };

            var gridSplitter = new GridSplitter()
            {
                Width = 5
            };

            Grid.SetColumn(securityNameLabel, 0);
            Grid.SetRow(securityNameLabel, 0);

            Grid.SetColumn(gridSplitter, 1);
            Grid.SetRow(gridSplitter, 0);

            Grid.SetColumn(currentPrice, 2);
            Grid.SetRow(currentPrice, 0);

            Grid.SetColumn(diff, 3);
            Grid.SetRow(gridSplitter, 0);

            grid.Children.Add(securityNameLabel);
            grid.Children.Add(gridSplitter);
            grid.Children.Add(currentPrice);
            grid.Children.Add(diff);

            border.Child = grid;

            _canvas.Children.Add(border);

            return border;
        }
    }
}
