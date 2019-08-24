using System.Data.Odbc;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeOnlyWpf.Windows
{
    public class CommandWindow : Window
    {
        public CommandWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Width = this.Height = 300;
            this.Top = this.Left = 300;

            var dockPanel = new DockPanel();

            var commandButton = new Button();
            commandButton.Content = "Command Button";
            commandButton.Command = ApplicationCommands.New;

            var commandButton2 = new Button();
            commandButton2.Content = "Command Button2";
            commandButton2.Command = ApplicationCommands.New;
            commandButton2.CommandParameter = "10086";

            #region CommandBinding
            CommandBinding commandBinding = new CommandBinding(ApplicationCommands.New);
            commandBinding.Executed += (sender, e) =>
            {
                var button = e.Source as Button;

                MessageBox.Show("Command Test Command." + sender + "\n" + button?.Content);
            };
            this.CommandBindings.Add(commandBinding);


            #endregion

            DockPanel.SetDock(commandButton, Dock.Top);
            DockPanel.SetDock(commandButton2, Dock.Top);

            dockPanel.Children.Add(commandButton);
            dockPanel.Children.Add(commandButton2);

            this.Content = dockPanel;
        }
    }
}
