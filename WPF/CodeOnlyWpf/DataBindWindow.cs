using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace WpfMvvm
{
    public class DataBindWindow : Window
    {
        public DataBindWindow()
        {
            InitializeCompoonent();
        }

        private void InitializeCompoonent()
        {
            #region element design
            var dockPanel = new DockPanel();

            var sliderBar = new Slider();
            sliderBar.Minimum = 1;
            sliderBar.Maximum = 100;
            sliderBar.Value = 20;
            sliderBar.TickFrequency = 1;
            sliderBar.TickPlacement = TickPlacement.TopLeft;

            var textBlock = new TextBlock();
            textBlock.Margin = new Thickness(10);
            textBlock.Text = "Simple Text";
            textBlock.FontSize = sliderBar.Value;

            var biggerButton = new Button();
            biggerButton.Content = "Bigger";

            var smallerButton = new Button();
            smallerButton.Content = "Smaller";

            DockPanel.SetDock(sliderBar, Dock.Top);
            DockPanel.SetDock(textBlock, Dock.Bottom);
            DockPanel.SetDock(biggerButton, Dock.Left);
            DockPanel.SetDock(smallerButton, Dock.Right);

            // 数据双向绑定，双向同时更新。
            var binding = new Binding();
            binding.Source = sliderBar;
            binding.Path = new PropertyPath("Value");
            binding.Mode = BindingMode.TwoWay;
            textBlock.SetBinding(TextBlock.FontSizeProperty, binding);
            #endregion

            #region event

            //sliderBar.ValueChanged += (sender, e) =>
            //{
            //    textBlock.FontSize = sliderBar.Value;
            //};

            //textBlock.SizeChanged += (sender, e) =>
            //{
            //    sliderBar.Value = textBlock.FontSize;
            //};

            biggerButton.Click += (sender, e) =>
            {
                textBlock.FontSize = 30;
            };

            smallerButton.Click += (sender, e) =>
            {
                textBlock.FontSize = 10;
            };
            #endregion

            dockPanel.Children.Add(sliderBar);
            dockPanel.Children.Add(textBlock);
            dockPanel.Children.Add(biggerButton);
            dockPanel.Children.Add(smallerButton);

            this.Content = dockPanel;
        }
    }
}
