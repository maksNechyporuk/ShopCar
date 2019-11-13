using CarShop.ClientsWindows;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CarShop.OrderWindows
{
    /// <summary>
    /// Interaction logic for SelectClientWindow.xaml
    /// </summary>
    public partial class SelectClientWindow : Window
    {
        List<ClientVM> client;
        ClientApiService servise;
        OrderVM _order;
        public SelectClientWindow()
        {
            InitializeComponent();
            servise = new ClientApiService();
            FillDG();

        }

        public SelectClientWindow(OrderVM order)
        {
            InitializeComponent();
            _order = order;
            servise = new ClientApiService();
            FillDG();

        }

       List<ClientVM> FillDGList(List<ClientVM> client)
        {
            List<ClientVM> clientDG = new List<ClientVM>();
            foreach (var item in client)
            {
                clientDG.Add(new ClientVM { Id = item.Id, Name = item.Name, Phone = item.Phone, Email = item.Email, Image = item.Image });
            }
            return clientDG;

        }
        async void FillDG()
        {
            var url = ConfigurationManager.AppSettings["siteURL"];

            client = await servise.GetClientsAsync(null);
            foreach (var item in client)
            {
                item.Image = url + "/" + item.Image;
            }
            dgShowClients.ItemsSource = FillDGList(client);
        }
        private async void BtnFindClient_Click(object sender, RoutedEventArgs e)
        {
            ClientApiService service = new ClientApiService();
            client = await service.GetClientsAsync(new ClientVM { Email = txtEmail.Text, Name = txtName.Text, Phone = txtNumber.Text });
            dgShowClients.ItemsSource = client;
        }



        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
          //  if (dgShowClients.SelectedItem != null)
            {
               // if (dgShowClients.SelectedItem is ClientDataGridVM)
                {
                    ClientVM client = (dgShowClients.SelectedItem as ClientVM);
                      OrderVerification window = new OrderVerification(new OrderVM { Car = _order.Car, Client = client });
                      window.ShowDialog();
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDG();
        }
    }
}
