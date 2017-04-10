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

namespace CheckBoxControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            var newVal = (CbAllFeatures.IsChecked == true);
            CbFeatureAbc.IsChecked = newVal;
            CbFeatureWww.IsChecked = newVal;
            CbFeatureXyz.IsChecked = newVal;
            
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CbAllFeatures.IsChecked = null;
            if ((CbFeatureAbc.IsChecked == true) && (CbFeatureWww.IsChecked == true) &&  (CbFeatureXyz.IsChecked == true))
                CbAllFeatures.IsChecked = true;
            if ((CbFeatureAbc.IsChecked == false)  && (CbFeatureXyz.IsChecked == false) && (CbFeatureWww.IsChecked == false))
                CbAllFeatures.IsChecked = false;
        }
    }
}
