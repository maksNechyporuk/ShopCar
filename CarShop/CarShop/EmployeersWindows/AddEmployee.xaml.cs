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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UserApiService userService = new UserApiService();
            try
            {
                lblName.Foreground = Brushes.White;
                lblEmail.Foreground = Brushes.White;
                lblPassword.Foreground = Brushes.White;
                lblName.Content = "";
                lblPassword.Content = "";
                lblEmail.Content = "";
                string req = await userService.RegisterAsync(new UserRegisterVM { Name = txtName.Text,Email = txtEmail.Text, Password = txtPassword.Text });
                MessageBox.Show("Працівник успішно доданий.");
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
                            Email = "",
                            Password = ""
                        });
                        if (mes.Name != null)
                        {
                            lblName.Content = mes.Name;
                        }
                        if(mes.Email!= null)
                        {
                            lblEmail.Content = mes.Email;
                        }
                        if (mes.Password != null)
                        {
                            lblPassword.Content = mes.Password;
                        }
                        lblName.Foreground = Brushes.Red;
                        lblEmail.Foreground = Brushes.Red;
                        lblPassword.Foreground = Brushes.Red;
                    }
                }
            }
        }
    }
}
