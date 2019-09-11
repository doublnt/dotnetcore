using System.Data.Odbc;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
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

            var button3 = new Button();
            button3.Content = "New Windows";
            button3.Click += (sender, e) =>
            {
                
            };
            #endregion

            DockPanel.SetDock(commandButton, Dock.Top);
            DockPanel.SetDock(commandButton2, Dock.Top);
            DockPanel.SetDock(button3,Dock.Right);

            dockPanel.Children.Add(commandButton);
            dockPanel.Children.Add(commandButton2);
            dockPanel.Children.Add(button3);

            this.Content = dockPanel;
        }
    }
}
