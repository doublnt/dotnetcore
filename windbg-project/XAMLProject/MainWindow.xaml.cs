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

            //BackTrack(3);
            //Test();
        }

        private void BackTrack(int count)
        {
            var list = new List<byte> { 0 };
            byte head = 1;

            for (int i = 0; i < count; ++i)
            {
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    var res = (byte)(head + list[j]);
                    list.Add(res);
                }

                head <<= 1;
            }

            for (int i = 0; i < list.Count; ++i)
            {
                Console.WriteLine(Convert.ToString(list[i], 2).PadLeft(count, '0'));
            }
        }
        public void Test()
        {
            A a = new A();
            a.Des();
            B b = new B();
            b.Des();
            C c = new C();
            c.Des();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class A
    {
        public void Des()
        {
            Console.WriteLine("ADes");
            Aes();
        }

        public virtual void Aes()
        {
            Console.WriteLine("AAes");
        }
    }

    public class B : A
    {
        public new void Aes()
        {
            Console.WriteLine("BAes");
        }
    }

    public class C : A
    {
        public override void Aes()
        {
            Console.WriteLine("CAes");
        }
    }
}
