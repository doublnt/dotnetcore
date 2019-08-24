using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace CodeOnlyWpf.Windows
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
            biggerButton.Width = biggerButton.Height = 100;
            biggerButton.Content = "Bigger";

            var smallerButton = new Button();
            smallerButton.Width = smallerButton.Height = 100;
            smallerButton.Content = "Smaller";

            var textBlock2 = new TextBlock();
            textBlock2.Text = "TextBlock2";

            DockPanel.SetDock(sliderBar, Dock.Top);
            DockPanel.SetDock(textBlock, Dock.Bottom);
            DockPanel.SetDock(biggerButton, Dock.Left);
            DockPanel.SetDock(smallerButton, Dock.Right);
            DockPanel.SetDock(textBlock2, Dock.Right);

            // 数据双向绑定，双向同时更新。
            BindTwoWayData(sliderBar, textBlock, BindingMode.TwoWay, TextBlock.FontSizeProperty);
            BindTwoWayData(sliderBar, textBlock2, BindingMode.TwoWay, TextBlock.FontSizeProperty);
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
            dockPanel.Children.Add(textBlock2);

            this.Content = dockPanel;
        }

        private void BindTwoWayData(FrameworkElement source, FrameworkElement target, BindingMode bindingMode, DependencyProperty property)
        {
            var binding = new Binding();
            binding.Source = source;
            binding.Path = new PropertyPath("Value");
            binding.Mode = bindingMode;
            binding.Delay = 2000;
            target.SetBinding(property, binding);
        }

        private void ClearAllBinding(FrameworkElement targetElement)
        {
            BindingOperations.ClearAllBindings(targetElement);
        }
    }
}
