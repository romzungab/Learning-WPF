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

namespace WPFEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PnlMainGrid.MouseUp += new MouseButtonEventHandler(pnlMainGrid_MouseUp);
            PnlMainGrid.MouseDown += PnlMainGridOnMouseDown;
        }

        private void PnlMainGridOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            throw new NotImplementedException();
        }


        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void PnlMainGrid_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

