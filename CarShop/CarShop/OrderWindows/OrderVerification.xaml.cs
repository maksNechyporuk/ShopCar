using CarShop.OrderWindows;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CarShop.ClientsWindows
{
    /// <summary>
    /// Interaction logic for OrderVerification.xaml
    /// </summary>
    public partial class OrderVerification : Window
    {
        static int code;
       static OrderVM _order;
        public  OrderVerification()
        {
            InitializeComponent();
        }
        public OrderVerification(OrderVM order)
        {
            _order = order;
            InitializeComponent();
            Send();
        }
        async void Send()
        {
            await SendEmailAsync();

            //OrderVerification orderVerification = new OrderVerification();
            //orderVerification.ShowDialog();
        }
        private static async Task SendEmailAsync()
        {
            string mail = _order.Client.Email;
            MailAddress from = new MailAddress("max.nechiporuk.2000@gmail.com");
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Підтвердження замовлення.";
            code = new Random().Next(10000, 99999);
            m.Body = $"Ваш код: {code}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("max.nechiporuk.2000@gmail.com", "76Avudep");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32( txtCode.Text) == code)
            {
                MessageBox.Show("Замовлення успішно підтвердженно.","Підтверження.");
                OrderApiService service = new OrderApiService();
                service.CreateAsync(new OrderAddVM { Car = _order.Car, Client = _order.Client,Date = DateTime.Now});
                ShowOrderWindow showOrderWindow = new ShowOrderWindow();
                showOrderWindow.Show();
               // this.Close();
            }
            else
            {
                MessageBox.Show("Введений код не збігається з кодом, який був відправлений.", "Підтверження.");
            }
        }
    }
}
