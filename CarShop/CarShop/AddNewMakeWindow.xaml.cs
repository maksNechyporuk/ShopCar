using System;
using System.Collections.Generic;
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
  
        public AddNewMakeWindow()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            //string query = $"Insert into tblCarMake(Make) values(@newMake)";

            //SQLiteCommand cmd = new SQLiteCommand(query, con);

            //con.Open();

            //DBGrid.ItemsSource = dataSet.Tables[0].DefaultView;

            //cmd.Dispose();
            //con.Close();

            con.Open();

            string query = $"Select * from tblCarMake";
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);
            dataAdapter.Fill(dataSet);
            DBGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            con.Close();
          


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
    }
}
