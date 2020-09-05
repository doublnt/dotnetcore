using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CodeOnlyWpf.Controls
{
    public class TimeSelect : Control
    {
        static TimeSelect()
        {
            FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata(new double(), FrameworkPropertyMetadataOptions.AffectsMeasure);
            ScrollProperty = DependencyProperty.Register("Scroll", typeof(double), typeof(FrameworkElement), metaData, new ValidateValueCallback(TimeSelect.IsScrollValid));
        }

        private static readonly DependencyProperty ScrollProperty;

        public double Scroll
        {
            get
            {
                return (double)GetValue(ScrollProperty);
            }
            set
            {
                SetValue(ScrollProperty, value);
            }
        }

        public static bool IsScrollValid(object value)
        {
            if (value is double result)
            {
                if (!double.IsNaN(result))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
