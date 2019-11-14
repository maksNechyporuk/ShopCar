using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            RefreshLabels();
            UserApiService service = new UserApiService();
            users = await service.GetUserAsync(new UserVM { Email = txtEmail.Text, Name = txtName.Text });
            dgShowEmployees.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshLabels();
            FillDG();
            txtEmail.Text = "";
            txtName.Text = "";
        }

        private void DgShowEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgShowEmployees.SelectedItem != null)
            {
                var employee = (UserVM)dgShowEmployees.SelectedItem;
                txtEmail.Text = employee.Email;
                txtName.Text = employee.Name;
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            RefreshLabels();
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            FillDG();
        }
        

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            RefreshLabels();
            MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete this employee ?","Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                UserApiService service = new UserApiService();
                var del_emp = (UserVM)dgShowEmployees.SelectedItem;
                servise.Delete(new UserDeleteVM { Id = del_emp.Id });
                FillDG();
                txtEmail.Text = "";
                txtName.Text = "";
            }
        }

        private void RefreshLabels()
        {
            lblName.Foreground = Brushes.White;
            lblEmail.Foreground = Brushes.White;
            lblName.Content = "";
            lblEmail.Content = "";
        }
        private async void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            UserApiService service = new UserApiService();
            int userid = 0;
            try
            {
                RefreshLabels();
                if (dgShowEmployees.SelectedItem != null)
                {
                    userid = (dgShowEmployees.SelectedItem as UserVM).Id;
                }
                string req = await service.UpdateAsync(new UserUpdateVM { Id = userid, Name = txtName.Text, Email = txtEmail.Text});
                MessageBox.Show("Працівник відредагований успішно.");
                txtEmail.Text = "";
                txtName.Text = "";
                FillDG();
                dgShowEmployees.SelectedItem = null;
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }
        void ShowException(WebException wex)
        {
            if (wex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)wex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var error = reader.ReadToEnd();
                        var mes = JsonConvert.DeserializeAnonymousType(error, new
                        {
                            Name = "",
                            Email = "",
                        });
                        if (mes.Name != null)
                        {
                            lblName.Content = mes.Name;
                        }
                        if (mes.Email != null)
                        {
                            lblEmail.Content = mes.Email;
                        }
                        lblName.Foreground = Brushes.Red;
                        lblEmail.Foreground = Brushes.Red;
                    }
                }
            }
        }
    }
}
