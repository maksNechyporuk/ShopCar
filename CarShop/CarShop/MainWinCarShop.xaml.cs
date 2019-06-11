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
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for MainWinCarShop.xaml
    /// </summary>
    public partial class MainWinCarShop : Window
    {
        public MainWinCarShop()
        {
            InitializeComponent();



        }

        private void BtnShowCar_Click(object sender, RoutedEventArgs e)
        {
            ShowCarWindow showCar = new ShowCarWindow();
            showCar.Show();
        }
    }
}
