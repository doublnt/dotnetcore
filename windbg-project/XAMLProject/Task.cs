using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XAMLProject
{
    public class Task : DependencyObject
    {
        public string TaskName { get; set; }

        public override string ToString()
        {
            return TaskName.ToString();
        }

        public static readonly DependencyProperty IsSpinningPropery = DependencyProperty.Register(
            "IsSpinning", typeof(bool), typeof(Task));

        public bool IsSpinning
        {
            get
            {
                return (bool)GetValue(IsSpinningPropery);
            }

            set
            {
                SetValue(IsSpinningPropery, value);
            }
        }
    }
}
