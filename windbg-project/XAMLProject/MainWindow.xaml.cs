using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XAMLProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://Application:,,,/DiyTemplateResources.xaml") });

            InitializeComponent();

            list_box.ItemsSource = InitializeList();
        }

        private List<Task> InitializeList()
        {
            var list = new List<Task>();
            list.Add(new Task() { TaskName = "Hellom,Woprllr", IsSpinning = true });
            list.Add(new Task { TaskName = "TYINXIXN", IsSpinning = false });
            list.Add(new Task { TaskName = "TTTTTT", IsSpinning = true });

            return list;
        }
    }
}
