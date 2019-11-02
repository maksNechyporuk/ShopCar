using CarShop.EmployeersWindows;
using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

namespace CarShop
{
    /// <summary>
    /// Interaction logic for LogInEmployee.xaml
    /// </summary>
    public partial class LogInEmployee : Window
    {
        private string userName;
        public LogInEmployee()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return userName;
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserApiService userService = new UserApiService();
            try
            {
                lblErrorName.Foreground = Brushes.White;
                lblErrorPassword.Foreground = Brushes.White;
                lblErrorName.Content = "";
                lblErrorPassword.Content = "";
                string req = await userService.LoginAsync(new UserLoginVM { Name = txtName.Text, Password = txtPassword.Text });
                MessageBox.Show("Ви успішно зареєструвались.");
                userName = txtName.Text;
                this.Close();
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
                            Password = ""
                        });
                        if (mes.Name != null)
                        {
                            lblErrorName.Content = mes.Name;
                        }
                        if (mes.Password != null)
                        {
                            lblErrorPassword.Content = mes.Password;
                        }
                        lblErrorName.Foreground = Brushes.Red;
                        lblErrorPassword.Foreground = Brushes.Red;
                    }
                }
            }
        }
    }
}
