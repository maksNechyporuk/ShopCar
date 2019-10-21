using CarShop.EmployeersWindows;
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
            if (txtName.Text != "" && txtPassword.Text != "")
            {
                var res = await userService.LoginAsync(new UserLoginVM { Name = txtName.Text, Password = txtPassword.Text });
                if (res == 1)
                {
                    MessageBox.Show("Ви успішно зареєструвались.");
                    ShowEmployees showEmployees = new ShowEmployees();
                    showEmployees.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильно введені дані.");
                    //txtName.Text = "";
                    //txtPassword.Text = "";
                }
            }
        }
    }
}
