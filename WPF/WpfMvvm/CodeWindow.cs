using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfMvvm
{
    public class CodeWindow : Window
    {
        private Button _button;

        public CodeWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Width = this.Height = 200;
            this.Left = this.Top = 100;
            this.Title = "Code-Only Window";

            #region Container
            DockPanel dockPanel = new DockPanel();

            _button = new Button();
            _button.Content = "Click Me";
            _button.Margin = new Thickness(30);

            _button.Click += (sender, eventArgs) =>
            {
                _button.Content = "Value Changed";
            };

            IAddChild container = dockPanel;
            container.AddChild(_button);

            container = this;
            container.AddChild(dockPanel);

            #endregion
        }
    }
}