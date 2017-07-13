using NeXt.Daud.Model;
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

namespace NeXt.Daud
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

        private void Daud_KoDOn(object sender, RoutedEventArgs e)
        {
            new KnifeOfDunwallSwitcher().Enable();
            MessageBox.Show("Done");
        }

        private void DaudKoDOff(object sender, RoutedEventArgs e)
        {
            new KnifeOfDunwallSwitcher().Disable();
            MessageBox.Show("Done");
        }

        private void Daud_BWOn(object sender, RoutedEventArgs e)
        {
            new BrigmoreWitchesSwitcher().Enable();
            MessageBox.Show("Done");
        }

        private void DaudBWOff(object sender, RoutedEventArgs e)
        {
            new BrigmoreWitchesSwitcher().Disable();
            MessageBox.Show("Done");
        }
    }
}
