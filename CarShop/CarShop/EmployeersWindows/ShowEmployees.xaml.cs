using ServiceDLL.Concrete;
using ServiceDLL.Models;
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

namespace CarShop.EmployeersWindows
{
    /// <summary>
    /// Interaction logic for ShowEmployees.xaml
    /// </summary>
    public partial class ShowEmployees : Window
    {
        UserApiService servise;
        public ShowEmployees()
        {
            InitializeComponent();
            servise = new UserApiService();
            FillDG();
        }

        async void  FillDG()
        {
            var users = await servise.GetUserAsync();
            dgShowEmployees.ItemsSource = users;
        }

        private void BtnFindEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
