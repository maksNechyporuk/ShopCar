using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Data;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        string dbName = "ShopCar.sqlite";
        public static List<Make> dataSource = new List<Make>();
        public AddNewCarWindow()
        {
            InitializeComponent();
            this.cbMake.Focus();
            

        SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            string query = $"Select * from  tblCarMake";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, con);
            dataAdapter.Fill(dataSet);
            while (reader.Read())
            {
                dataSource.Add(new Make { Name = reader["Make"].ToString(), CityID = int.Parse(reader["Id"].ToString()) });             
            }
            
           cbMake.ItemsSource = dataSet.Tables[0].DefaultView;
           cbMake.SelectedValuePath = dataSet.Tables[0].Columns["Id"].ToString();
           cbMake.DisplayMemberPath = dataSet.Tables[0].Columns["Make"].ToString();
           //cbMake.ItemsSource=make;           
        }
        //protected void autoCities_PatternChanged(object sender, AutoComplete.AutoCompleteArgs args)
        //{
        //    //check
        //    if (string.IsNullOrEmpty(args.Pattern))
        //        args.CancelBinding = true;
        //    else
        //        args.DataSource =GetCities(args.Pattern);
        //}
        //private static ObservableCollection<Make> GetCities(string Pattern)
        //{
        //    // match on contain (could do starts with)
        //    return new ObservableCollection<Make>(
        //        dataSource.Where((city, match) => city.Name.ToLower().Contains(Pattern.ToLower())));
        //}
        private void CbMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show(cbMake.SelectedValue.ToString());
        }
    }
}
