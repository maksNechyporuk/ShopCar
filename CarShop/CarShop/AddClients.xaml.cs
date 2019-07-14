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
        UserService service;
        public ObservableCollection<ClientVM> clients = new ObservableCollection<ClientVM>();
        public bool check = false;
        public string ImgName;
        string imageFolderSave = "ClientsPictures";
        string PathImagDic;
        public AddClients()
        {
            InitializeComponent();
            service = new UserService(this);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public class UserService
        {
            AddClients window;
            public UserService(AddClients main)
            {
                window = main;
            }
            public void Insert()
            {
                SQLiteConnection con = new SQLiteConnection($"Data source={"dbUsers.sqlite"};datetimeformat=CurrentCulture");
                con.Open();
                string name = window.txtName.Text;

                string query = $"Insert into tblClient(Name,Image) values('{name}','{  window.ImgName}')";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                window.check = false;
                window.txtName.Clear();

                window.img.Source = null;
                //window.SearchUsers();
            }
            public void Edit()
            {
                SQLiteConnection con = new SQLiteConnection($"Data source={"dbUsers.sqlite"};datetimeformat=CurrentCulture");
                //window.btnUpdate.IsEnabled = true;
                if (window.dgViewDB.SelectedItem != null)
                {
                    window.btnAdd.IsEnabled = false;
                    window.btnAddImg.IsEnabled = false;
                    //window.btnSearch.IsEnabled = false;
                    int ind = 0;
                    ind = window.clients.IndexOf(window.dgViewDB.SelectedItem as ClientVM);
                    //window.lblId.Content = window.clients[ind].Id;
                    window.txtName.Text = window.clients[ind].Name;
                    window.img.Source = new BitmapImage(new Uri(window.clients[ind].PathImg));
                }
            }
            public void Delete()
            {
                SQLiteConnection con = new SQLiteConnection($"Data source={"dbUsers.sqlite"};datetimeformat=CurrentCulture");
                //  try
                {

                    if (window.dgViewDB.SelectedItem != null)
                    {
                        int ind = 0;
                        ind = window.clients.IndexOf(window.dgViewDB.SelectedItem as ClientVM);


                        SQLiteCommand cmd;
                        con.Open();
                        string query = $"Delete FROM tblUsers where Id='{window.clients[ind].Id}'";
                        cmd = new SQLiteCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        window.clients.RemoveAt(ind);
                        //window.SearchUsers();
                    }
                }
            }
            public void Update()
            {
                SQLiteConnection con = new SQLiteConnection($"Data source={"dbUsers.sqlite"};datetimeformat=CurrentCulture");
                try
                {
                    con.Open();

                    SQLiteCommand cmd = new SQLiteCommand("UPDATE tblUsers Set Name=@Name  Where Id=@Id", con);
                    cmd.Parameters.AddWithValue("Id", window.lblId.Content);
                    cmd.Parameters.AddWithValue("Name", window.txtName.Text);
                    window.btnAdd.IsEnabled = true;
                    window.btnAddImg.IsEnabled = true;
                    //window.btnSearch.IsEnabled = true;
                    window.btnAdd.IsEnabled = true;

                    cmd.ExecuteNonQuery();
                    con.Close();
                    window.txtName.Clear();


                    window.img.Source = null;
                    //window.SearchUsers();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
