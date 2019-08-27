using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CodeOnlyWpf.Windows
{
    public class ProcessBarGridWindow : Window
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private int _processBarValue = 40;

        public ProcessBarGridWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            BaseWindowConfiguration.Initialize(this);

            var grid = new Grid();

            var column1 = new ColumnDefinition();
            var column2 = new ColumnDefinition();

            var row1 = new RowDefinition();
            var row2 = new RowDefinition();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);

            var processBar1 = new ProgressBar();
            processBar1.Orientation = Orientation.Horizontal;
            processBar1.Visibility = Visibility.Visible;
            processBar1.Maximum = 100;
            processBar1.Value = _processBarValue;
            processBar1.Foreground = new SolidColorBrush(Color.FromRgb(255,0,0));
            RotateTransform rotateTransform = new RotateTransform(180);

            processBar1.LayoutTransform = rotateTransform;

            Grid.SetColumn(processBar1, 0);
            Grid.SetRow(processBar1, 0);
            grid.Children.Add(processBar1);

            var button1 = new Button();
            button1.Content = "Generate Number";
            button1.Click += (sender, e) =>
            {
                processBar1.Value = Random.Next(100);
            };

            Grid.SetColumn(button1, 1);
            Grid.SetRow(button1, 0);
            grid.Children.Add(button1);

            var textBlock = new TextBlock();
            textBlock.FontSize = 30;
            textBlock.Text = _processBarValue.ToString();

            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, 1);

            grid.Children.Add(textBlock);

            this.Content = grid;
        }
    }
}
