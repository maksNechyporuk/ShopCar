using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
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
    /// Interaction logic for AddNewMakeWindow.xaml
    /// </summary>
    public partial class AddNewMakeWindow : Window
    {
        string dbName = "ShopCar.sqlite";
      
        private string tblCarMake = "tblCarMake";
        private ObservableCollection<MakeViewModels> MakeVM { get; set; }
        public AddNewMakeWindow()
        {
            InitializeComponent();
            MakeVM = new ObservableCollection<MakeViewModels>();
           
            DBGrid.ItemsSource = MakeVM;        
        }

        private void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            string query = $"Insert into tblCarMake(Make) values(@newMake)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@newMake", txtMake.Text);
            
            try {
                cmd.ExecuteNonQuery();
                txtMake.Clear();

            }
            catch
           {

            }
        }

        private void DBGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
