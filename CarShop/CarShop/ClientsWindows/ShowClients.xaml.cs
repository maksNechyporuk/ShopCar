using Microsoft.Win32;
using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Helpers;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        string main_base64Image;
        List<ClientVM> FillDGList(List<ClientVM> client)
        {
            List<ClientVM> clientDG = new List<ClientVM>();
            foreach (var item in client)
            {
                clientDG.Add(new ClientVM { Id = item.Id, Name = item.Name, Phone = item.Phone, Email = item.Email,Image=item.Image });
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
            var url = ConfigurationManager.AppSettings["siteURL"];

            client = await servise.GetClientsAsync(null);
            foreach (var item in client)
            {
                item.Image = url + "/" + item.Image;
            }
            dgShowClients.ItemsSource = FillDGList(client);
        }

        void FillDGByFind(List<ClientVM> list)
        {
            dgShowClients.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDG();
            PhotoClient = null;
            txtNumber.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
        }

        private async void BtnFindClient_Click(object sender, RoutedEventArgs e)
        {
            var url = ConfigurationManager.AppSettings["siteURL"];

            ClientApiService service = new ClientApiService();
            client = await service.GetClientsAsync(new ClientVM { Email = txtEmail.Text, Name = txtName.Text, Phone = txtNumber.Text });
            foreach (var item in client)
            {
                item.Image = url + "/" + item.Image;
            }
            dgShowClients.ItemsSource = client;
        }

        private async void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblPhoneError.Foreground = System.Windows.Media.Brushes.White;
                lblNameError.Foreground = System.Windows.Media.Brushes.White;
                lblEmailError.Foreground = System.Windows.Media.Brushes.White;
                lblPhotoError.Foreground = System.Windows.Media.Brushes.White;
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
                await service.CreateAsync(new ClientAddVM { Name = txtName.Text, Phone = txtNumber.Text,Image = main_base64Image,Email = txtEmail.Text,UniqueName = Guid.NewGuid().ToString()
            });
                FillDG();
                PhotoClient = null;
                txtNumber.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                lblPhoneError.Content = "";
                lblPhotoError.Content = "";
                lblNameError.Content = "";
                lblEmailError.Content = "";
                lblPhoneError.Foreground = System.Windows.Media.Brushes.White;
                lblPhotoError.Foreground = System.Windows.Media.Brushes.White;
                lblNameError.Foreground = System.Windows.Media.Brushes.White;
                lblEmailError.Foreground = System.Windows.Media.Brushes.White;
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            ClientVM client = (ClientVM)dgShowClients.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Ви впевнені,що хочете видалити клієнта " + client.Name + "?", "Видалення", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ClientApiService service = new ClientApiService();
                service.Delete(new ClientDeleteVM { Id = client.Id });
                FillDG();
            }
        }

        private async void BtnAcceptChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientVM client = (ClientVM)dgShowClients.SelectedItem;
                string str = txtNumber.Text;
                string str2 = txtName.Text;
                string str3 = txtEmail.Text;
                if (str != null && str.Trim().Length == 10)
                    str = string.Format("+38{0}({1}){2}-{3}-{4}", str.Substring(0, 1), str.Substring(1, 2), str.Substring(3, 3), str.Substring(6, 2), str.Substring(8, 2));
                txtNumber.Text = str;
                txtName.Text = str2;
                txtEmail.Text = str3;
                ClientApiService service = new ClientApiService();
                await service.UpdateAsync(new ClientVM { Id = client.Id, Name = txtName.Text, Phone = txtNumber.Text, Email = txtEmail.Text });
                FillDG();
                txtNumber.Text = "";
                txtName.Text = "";
                txtEmail.Text = "";
                lblPhoneError.Foreground = System.Windows.Media.Brushes.White;
                lblNameError.Foreground = System.Windows.Media.Brushes.White;
                lblEmailError.Foreground = System.Windows.Media.Brushes.White;
                lblPhotoError.Foreground = System.Windows.Media.Brushes.White;
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }

        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            var item = dgShowClients.SelectedItem;
            ClientVM client = (ClientVM)dgShowClients.SelectedItem;
            txtName.Text = client.Name;
            txtNumber.Text = client.Phone;
            txtEmail.Text = client.Email;
        }

        private void DgShowClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgShowClients.SelectedItem != null)
            {
               if(dgShowClients.SelectedItem is ClientVM)
                {
                ClientVM client = (ClientVM)dgShowClients.SelectedItem;
                btnChoose.IsEnabled = true;
                btnAcceptChanges.IsEnabled = true;
                btnDeleteClient.IsEnabled = true;
                }
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
                            Email = "",
                            Image = ""
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
                            if (mes.Phone == "issue")
                            {
                                txtNumber.BorderBrush = System.Windows.Media.Brushes.Red;
                                lblPhoneError.Visibility = Visibility;
                            }
                            else
                                lblPhoneError.Content = mes.Phone;
                        }
                        if (mes.Email != null)
                        {
                            if (mes.Email == "issue")
                            {
                                txtEmail.BorderBrush = System.Windows.Media.Brushes.Red;
                                lblEmailError.Visibility = Visibility;
                            }
                            else
                                lblEmailError.Content = mes.Email;
                        }
                        if (mes.Image != null)
                        {
                            if (mes.Image == "issue")
                            {                            
                                lblPhotoError.Visibility = Visibility;
                            }
                            else
                                lblPhotoError.Content = mes.Image;
                        }
                        lblNameError.Foreground = System.Windows.Media.Brushes.Red;
                        lblPhoneError.Foreground = System.Windows.Media.Brushes.Red;
                        lblEmailError.Foreground = System.Windows.Media.Brushes.Red;
                        lblPhotoError.Foreground = System.Windows.Media.Brushes.Red;

                    }
                }
            }
        }
        void ShowMessage(string mes)
        {
            mes = mes.Trim('"');
            MessageBox.Show(mes);
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtName.BorderBrush = System.Windows.Media.Brushes.Gray;
            lblNameError.Content = "";
        }

        private void TxtNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtNumber.BorderBrush = System.Windows.Media.Brushes.Gray;
            lblPhoneError.Content = "";
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEmail.BorderBrush = System.Windows.Media.Brushes.Gray;
            lblEmailError.Content = "";
        }

        private void BtnAddImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
                "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (dlg.ShowDialog() == true)
            {
                PhotoClient.Source = new BitmapImage(new Uri(dlg.FileName));
                var b = ConvertBitmapSourceToByteArray(PhotoClient.Source as BitmapSource);
                main_base64Image = Convert.ToBase64String(b);
            }
        }     
        public static byte[] ConvertBitmapSourceToByteArray(BitmapSource image)
        {
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}