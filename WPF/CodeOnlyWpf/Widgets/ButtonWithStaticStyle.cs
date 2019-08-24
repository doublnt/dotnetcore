using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace CodeOnlyWpf.Widgets
{
    public class ButtonWithStaticStyle
    {
        private static Button _button;

        private static void InitializeComponent()
        {
            _button = new Button();
            //_button.FontSize = double.Parse(currentWindow.Resources["ButtonFontSize"].ToString());
            //_button.FontWeight = (FontWeight)currentWindow.TryFindResource("ButtonFontWeight");
            //_button.FontFamily = currentWindow.TryFindResource("ButtonFontFamily") as FontFamily;
            _button.Style = Application.Current.TryFindResource("BigFontButtonStyle") as Style;
        }

        public static Button GetCurrentControl()
        {
            InitializeComponent();

            return _button;
        }
    }
}
