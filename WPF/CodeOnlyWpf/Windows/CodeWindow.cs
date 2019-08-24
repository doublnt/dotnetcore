using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using CodeOnlyWpf.Widgets;

namespace CodeOnlyWpf.Windows
{
    public class CodeWindow : Window
    {
        private Button _button;

        public CodeWindow()
        {
            LoadResourcesAndRegisterGlobal();

            InitializeComponent();
        }

        private void LoadResourcesAndRegisterGlobal()
        {
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri("/Resources/ButtonStyle.xaml", UriKind.RelativeOrAbsolute)
            };

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
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

            var button2 = ButtonWithStaticStyle.GetCurrentControl();
            button2.Content = "1111";

            dockPanel.Children.Add(_button);
            dockPanel.Children.Add(button2);

            dockPanel.MouseLeave += (sender, eventArgs) => { _button.Content = "Mouse has move over here."; };

            _button.MouseEnter += (sender, eventArgs) =>
            {
                _button.Content = "Mouse has move in the button areas.";
            };

            this.Content = dockPanel;
            #endregion
        }
    }
}
