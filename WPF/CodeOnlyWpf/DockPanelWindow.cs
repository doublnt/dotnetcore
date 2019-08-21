using System.Windows;
using System.Windows.Controls;

namespace WpfMvvm
{
    public class DockPanelWindow : Window
    {
        public DockPanelWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Width = this.Height = 300;
            this.Left = this.Top = 300;
            this.Title = "Dock panel test";

            var dockPanel = new DockPanel();
            dockPanel.LastChildFill = false;

            var buttonTop = new Button();
            buttonTop.Content = "ButtonTop";
            DockPanel.SetDock(buttonTop, Dock.Top);

            var buttonBottom = new Button();
            buttonBottom.Content = "ButtonBottom";
            DockPanel.SetDock(buttonBottom, Dock.Bottom);

            dockPanel.Children.Add(buttonTop);
            dockPanel.Children.Add(buttonBottom);

            this.Content = dockPanel;
        }
    }
}
