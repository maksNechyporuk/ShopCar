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
        public LogInEmployee()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserApiService userService = new UserApiService();
            try
            {
                    var token = await userService.LoginAsync(new UserLoginVM { Name = txtName.Text, Password = txtPassword.Text });
                    var tokenObject = JsonConvert.DeserializeAnonymousType(token, new
                    {
                        token = ""
                    });
                    
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(tokenObject.token);
                    var tokenS = handler.ReadToken(tokenObject.token) as JwtSecurityToken;
                    foreach (var item in tokenS.Claims)
                    {
                        MessageBox.Show($"{item.Value}", item.Type);
                    }
                    MessageBox.Show(token);
                    MessageBox.Show("Ви успішно зареєструвались.");
                    ShowEmployees showEmployees = new ShowEmployees();
                    showEmployees.Show();
                    this.Close();
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
