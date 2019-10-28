using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Helpers;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace CarShop.ClientsWindows
{
    /// <summary>
    /// Interaction logic for ShowClients.xaml
    /// </summary>
    public partial class ShowClients : Window
    {
        ClientApiService servise;
        List<ClientVM> client;

        List<ClientDataGridVM> FillDGList(List<ClientVM> client)
        {
            List<ClientDataGridVM> clientDG = new List<ClientDataGridVM>();
            foreach (var item in client)
            {
                //Bitmap img = item.Image.Base64ToImage();
                clientDG.Add(new ClientDataGridVM { Id = item.Id, Name = item.Name, Phone = item.Phone/*, Image = img*/ });
                //PhotoImage = img. ;
            }
            return clientDG;

        }
        public ShowClients()
        {
            InitializeComponent();
            servise = new ClientApiService();
            FillDG();
        }

        async void FillDG()
        {
            client = await servise.GetClientsAsync();
            dgShowClients.ItemsSource = FillDGList(client);
        }

        void FillDGByFind(List<ClientVM> list)
        {
            dgShowClients.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDG();
        }

        private void BtnFindClient_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != "" && txtName.Text != "")
            {
                dgShowClients.ItemsSource = client.Where(c => c.Phone == txtNumber.Text && c.Name == txtName.Text);
            }
            else if (txtNumber.Text != "")
            {
                dgShowClients.ItemsSource = client.Where(c => c.Phone == txtNumber.Text);
            }
            else
            {
                dgShowClients.ItemsSource = client.Where(c => c.Name == txtName.Text);
            }
        }

        private async void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblPhoneError.Foreground = System.Windows.Media.Brushes.White;
                lblNameError.Foreground = System.Windows.Media.Brushes.White;
                lblPhoneError.Content = "";
                lblNameError.Content = "";
                ClientApiService service = new ClientApiService();              
                ShowMessage(await service.CreateAsync(new ClientAddVM { Name = txtName.Text,Phone = txtNumber.Text}));
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
                            Phone = ""
                        });
                        if (mes.Name != null)
                        {
                            lblNameError.Content = mes.Name;
                        }
                        if (mes.Phone != null)
                        {
                            lblPhoneError.Content = mes.Phone;
                        }
                        lblNameError.Foreground = System.Windows.Media.Brushes.Red;
                        lblPhoneError.Foreground = System.Windows.Media.Brushes.Red;
                    }
                }
            }
        }
        void ShowMessage(string mes)
        {
            mes = mes.Trim('"');
            MessageBox.Show(mes);
        }
    }
}

