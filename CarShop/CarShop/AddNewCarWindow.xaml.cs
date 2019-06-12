using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        string dbName = "ShopCar.sqlite";

        public AddNewCarWindow()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();

            string query = $"Select * from  tblCarMake";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
          List<string> make=new List<string>();
            while(reader.Read())
            {
               // cbMake.SelectedValuePath = reader["Id"].ToString();

                make.Add(reader["Make"].ToString());
                
            }
            while (reader.Read())
            {
                cbMake.SelectedValuePath = reader["Id"].ToString();
            }
            cbMake.ItemsSource=make;
           
        }

        private void CbMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(cbMake.SelectedValue.ToString());
        }
    }
}
