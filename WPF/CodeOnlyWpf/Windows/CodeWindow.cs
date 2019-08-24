using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace CodeOnlyWpf.Windows
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
            this.Width = this.Height = 400;
            this.Left = this.Top = 200;
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

            dockPanel.MouseLeave += (sender, eventArgs) => { _button.Content = "Mouse has move over here."; };

            _button.MouseEnter += (sender, eventArgs) =>
            {
                _button.Content = "Mouse has move in the button areas.";
            };

            #endregion
        }
    }
}
