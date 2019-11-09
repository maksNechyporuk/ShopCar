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
        List<UserVM> users;
        public ShowEmployees()
        {
            InitializeComponent();
            servise = new UserApiService();
            FillDG();
        }

        async void FillDG()
        {
            users = await servise.GetUserAsync(null);
            dgShowEmployees.ItemsSource = users;
        }

        void FillDGByFind(List<UserVM> list)
        {
            dgShowEmployees.ItemsSource = list;
        }

        private async void BtnFindEmployee_Click(object sender, RoutedEventArgs e)
        {
            UserApiService service = new UserApiService();
            users = await service.GetUserAsync(new UserVM { Email = txtEmail.Text, Name = txtName.Text });
            dgShowEmployees.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDG();
        }

        private void DgShowEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
