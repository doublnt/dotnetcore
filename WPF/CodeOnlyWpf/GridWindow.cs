using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;

namespace WpfMvvm
{
    public class GridWindow : Window
    {
        public GridWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Width = this.Height = 300;
            this.Left = this.Top = 300;
            this.Title = "Grid Test";

            #region Grid Define0
            var grid = new Grid();
            grid.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClickMethod));
            grid.ShowGridLines = true;

            var column1 = new ColumnDefinition();
            var column2 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);

            var row1 = new RowDefinition();
            var row2 = new RowDefinition();

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            #endregion

            var button1 = new Button();
            button1.Content = "Test Grid";

            button1.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClickMethod));

            Grid.SetColumn(button1, 0);
            Grid.SetRow(button1, 0);

            // 和上面两句一个意思
            button1.SetValue(Grid.RowProperty, 0);
            button1.SetValue(Grid.ColumnProperty, 0);

            grid.Children.Add(button1);

            this.Content = grid;

            //button1.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClickMethod));

            //FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
            //frameworkPropertyMetadata.CoerceValueCallback = new CoerceValueCallback();

            //DependencyProperty.Register("Margin", typeof(Thickness), typeof(FrameworkElement),
            //    frameworkPropertyMetadata);
        }

        private void ButtonClickMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Bubble Routed Event, hello, sender is" + sender);
        }
    }
}
