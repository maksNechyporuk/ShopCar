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
    /// Interaction logic for AddNewModelWindow.xaml
    /// </summary>
    public partial class AddNewModelWindow : Window
    {
        string dbName = "ShopCar.sqlite";
        public static List<Make> dataSource = new List<Make>();
       
        public AddNewModelWindow()
        {
            InitializeComponent();
            this.cbMake.Focus();

            FillDG();
        }
        void FillDG()
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            string query = $"Select * from  tblCarMake";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);
            dataAdapter.Fill(dataSet);
            //while (reader.Read())
            //{
            //    dataSource.Add(new Make { Name = reader["Make"].ToString(), CityID = int.Parse(reader["Id"].ToString()) });
            //}

            cbMake.ItemsSource = dataSet.Tables[0].DefaultView;
            cbMake.SelectedValuePath = dataSet.Tables[0].Columns["Id"].ToString();
            cbMake.DisplayMemberPath = dataSet.Tables[0].Columns["Make"].ToString();
            con.Close();
            con.Open();

            query = $"Select * from tblCarModel";
            dataSet = new DataSet();
            dataAdapter = new SQLiteDataAdapter(query, con);
            dataAdapter.Fill(dataSet);
            DBGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            con.Close();
        }
            private void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            string query = $"Insert into tblCarModel(Id_Make,Model) values(@IdMake,@Model)";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@IdMake", cbMake.SelectedValue);
            cmd.Parameters.AddWithValue("@Model", txtModel.Text);

            try
            {
                cmd.ExecuteNonQuery();
                txtModel.Clear();
                con.Close();
            }
            catch
            {

            }
            FillDG();
        }

      
    }
}
