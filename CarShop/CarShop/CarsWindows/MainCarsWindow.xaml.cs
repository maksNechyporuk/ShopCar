using CarShop.CarsWindows;
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
    /// Interaction logic for ShowCarWindow.xaml
    /// </summary>
    public partial class MainCarWindow : Window
    {
        public MainCarWindow()
        {
            InitializeComponent();
        }


        private void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {
            AddNewMakeWindow makeWindow = new AddNewMakeWindow();
            makeWindow.ShowDialog();
        }

        private void BtnAddModel_Click(object sender, RoutedEventArgs e)
        {
            AddNewModelWindow makeWindow = new AddNewModelWindow();
            makeWindow.ShowDialog();
        }

        private void BtnAddNewCar_Click(object sender, RoutedEventArgs e)
        {
            AddNewCarWindow window = new AddNewCarWindow();
            window.ShowDialog();
        }

        private void BtnShowCars_Click(object sender, RoutedEventArgs e)
        {
            ShowCarsWindow addNewCar = new ShowCarsWindow();
            addNewCar.ShowDialog();
        }
    }
}
