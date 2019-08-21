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
using CarShop.Entities;
using CarShop.ViewModels;
using Microsoft.Win32;
using WPFAnimal.Extensions;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        private ObservableCollection<ClientViewModels> ClientVM { get; set; }
        private readonly EFcontext _context;
        public bool check = false;
        public string ImgName;
        string imageFolderSave = "ClientsPictures";
        string PathImagDic;
        public AddClients()
        {
            InitializeComponent();         
            PathImagDic = System.IO.Path.Combine(Directory.GetCurrentDirectory(), imageFolderSave);
            ClientVM = new ObservableCollection<ClientViewModels>();
            _context = new EFcontext();
            FillDB();
        }
        void FillDB()
        {
            try
            {
                var query = _context.Makes.AsQueryable();
                var list = query.Select(at => new ClientViewModels
                {
                    Id = at.Id,
                    Name = at.Name
                }).ToList();
                ClientVM.Clear();
                ClientVM.AddRange(list);
            }
            catch { }
        }
        private void BtnImage_Click(object sender, RoutedEventArgs e)
        {
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
            if (txtName.Text == "" && txtSurname.Text == "" && txtPhone.Text == "" && ImgName=="")
            {
                MessageBox.Show("Please, fill all lines.");
            }
            else
            {
                var list = _context.Clients.AsQueryable().ToList();
                bool c = false;
                foreach (var item in list)
                {
                    if (item.Phone == txtPhone.Text)
                        c = true;
                }
                if (c == true)
                {
                    MessageBox.Show("Error");
                }
                if (c == false)
                {
                    _context.Clients.Add(new Entities.Client {
                        Name = txtName.Text + " " + txtSurname.Text,
                        Image = ImgName,
                        Phone = txtPhone.Text,
                        Password = txtPassword.Text
                    });
                    _context.SaveChanges();
                    FillDB();
                    MessageBox.Show("You succesfully registered!");
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserAdd();
        }
    }
    }
