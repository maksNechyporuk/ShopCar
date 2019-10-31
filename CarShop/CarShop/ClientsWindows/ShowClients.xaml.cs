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
using System.Text.RegularExpressions;
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
                clientDG.Add(new ClientDataGridVM { Id = item.Id, Name = item.Name, Phone = item.Phone,Email = item.Email/*, Image = img*/ });
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
            if (txtNumber.Text != "" && txtName.Text != "" && txtEmail.Text !="")
            {
                dgShowClients.ItemsSource = client.Where(c => c.Phone == txtNumber.Text && c.Name == txtName.Text && c.Email == txtEmail.Text);
            }
            else if (txtNumber.Text != "")
            {
                dgShowClients.ItemsSource = client.Where(c => c.Phone == txtNumber.Text);
            }
            else if (txtEmail.Text != "")
            {
                dgShowClients.ItemsSource = client.Where(c => c.Email == txtEmail.Text);
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
                lblEmailError.Foreground = System.Windows.Media.Brushes.White;
                lblPhoneError.Content = "";
                lblNameError.Content = "";
                lblEmailError.Content = "";
                string str = txtNumber.Text;
                string str2 = txtName.Text;
                string str3 = txtEmail.Text;
                if (str != null && str.Trim().Length == 10)
                    str = string.Format("+38{0}({1}){2}-{3}-{4}", str.Substring(0, 1), str.Substring(1, 2), str.Substring(3, 3), str.Substring(6, 2), str.Substring(8, 2));
                txtNumber.Text = str;
                txtName.Text = str2;
                txtEmail.Text = str3;              
                ClientApiService service = new ClientApiService();
                await service.CreateAsync(new ClientAddVM { Name = txtName.Text, Phone = txtNumber.Text, Email = txtEmail.Text });
                FillDG();

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
                            Phone = "",
                            Email = ""
                        });
                        if (mes.Name != null)
                        {
                            if (mes.Name == "issue")
                            {
                                txtName.BorderBrush = System.Windows.Media.Brushes.Red;
                                lblNameError.Visibility = Visibility;
                            }
                            else
                            lblNameError.Content = mes.Name;
                        }
                        if (mes.Phone != null)
                        {
                            if(mes.Phone == "issue")
                            {
                                txtNumber.BorderBrush = System.Windows.Media.Brushes.Red;
                                lblPhoneError.Visibility = Visibility;
                            }
                            else
                            lblPhoneError.Content = mes.Phone;                         
                        }
                        if (mes.Email != null)
                        {
                            //if (mes.Email == "issue")
                            //{
                            //    txtEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                            //    lblEmailError.Visibility = Visibility;
                            //}
                            //else
                            //lblEmailError.Content = mes.Email;
                        }

                        lblNameError.Foreground = System.Windows.Media.Brushes.Red;
                        lblPhoneError.Foreground = System.Windows.Media.Brushes.Red;
                        lblEmailError.Foreground = System.Windows.Media.Brushes.Red;
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

