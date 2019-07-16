using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
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
using Microsoft.Win32;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {      
        public ObservableCollection<ClientVM> clients = new ObservableCollection<ClientVM>();
        public bool check = false;
        public string ImgName;
        string imageFolderSave = "ClientsPictures";
        string PathImagDic;
        public AddClients()
        {
            InitializeComponent();         
            PathImagDic = System.IO.Path.Combine(Directory.GetCurrentDirectory(), imageFolderSave);
        }
        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
            string ImgName;
            string imageFolderSave = "ClientsPictures";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
                "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (dlg.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(dlg.FileName));
                try
                {
                    var filePath = dlg.FileName;
                    var image = System.Drawing.Image.FromFile(dlg.FileName);
                    ImgName = Guid.NewGuid().ToString() + ".jpg";
                    File.Copy(filePath, System.IO.Path.Combine(imageFolderSave, ImgName));
                    if (!Directory.Exists(imageFolderSave))
                    {
                        Directory.CreateDirectory(imageFolderSave);
                    }
                    var bmpOrigin = new System.Drawing.Bitmap(image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something Wrong {ex.Message}");
                }
            }
        }
        private void UserAdd()
        {

        }
    }
    }
