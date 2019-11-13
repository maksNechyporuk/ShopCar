using CarShop.ClientsWindows;
using CarShop.EmployeersWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace CarShop
{
    /// <summary>
    /// Interaction logic for MainWinCarShop.xaml
    /// </summary>
    public partial class MainWinCarShop : Window
    {

        // public ObservableCollection<Car> Cars = new ObservableCollection<Car>();
        static int code;
        public MainWinCarShop()
        {
            InitializeComponent();
        }           
        private void BtnShowCar_Click(object sender, RoutedEventArgs e)
        {
            MainCarWindow showCar = new MainCarWindow();           
            showCar.Show();
        }
        private void BtnEng_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["setLang"].Value = "en-US";
            config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.AppSettings["setLang"] = "ru";
            this.Restart();
        }

        private void BtnUk_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["setLang"].Value = "uk";
            config.Save(ConfigurationSaveMode.Modified);
            this.Restart();
        }
        private void Restart()
        {
            System.Diagnostics.Process
                .Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnShowClients_Click(object sender, RoutedEventArgs e)
        {
            ShowClients showClients = new ShowClients();
            showClients.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowEmployees showEmployees = new ShowEmployees();
            showEmployees.Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LogInEmployee logInEmployee = new LogInEmployee();
            logInEmployee.ShowDialog();
            lblUserName.Text = logInEmployee.GetName();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await SendEmailAsync();
            OrderVerification orderVerification = new OrderVerification();
            orderVerification.verCode = code;
            orderVerification.ShowDialog();
        }

        private static async Task SendEmailAsync()
        {
            MailAddress from = new MailAddress("tereshkovychura@gmail.com", "CarShop");
            MailAddress to = new MailAddress("tereshkovychura@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Підтвердження замовлення.";
            code = new Random().Next(10000, 99999);
            m.Body = $"Ваш код: {code}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("tereshkovychura@gmail.com", "7080900pol");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
