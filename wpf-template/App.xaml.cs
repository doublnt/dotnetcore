using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using wpf_template.Model;

namespace wpf_template
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
        private void AppStartup(object sender, StartupEventArgs e)
        {
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Resources/ControlResources.xaml") });
            LoadPhotoData();
        }

        private void LoadPhotoData()
        {
            var ph1 = new Photo("羿", "D://Location", true);
            var ph2 = new Photo("上", "C://Location", true);

            Photos.Add(ph1);
            Photos.Add(ph2);
        }
    }
}
