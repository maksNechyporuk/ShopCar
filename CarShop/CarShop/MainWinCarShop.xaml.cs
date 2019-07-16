using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for MainWinCarShop.xaml
    /// </summary>
    public partial class MainWinCarShop : Window
    {
        string dbName = "ShopCar.sqlite";
        private string tblCars = "tblCars"; 
        private string tblColor = "tblColor"; 
        private string tblCarModel = "tblCarModel"; 
        private string tblCarMake = "tblCarMake"; 
        private string tblFuel_type = "tblFuel_type"; 
        private string tblTypeCar = "tblTypeCar";
        private string tblOrder = "tblOrder"; 
        private string tblPurchase = "tblPurchase"; 
        private string tblClient = "tblClient";
        public ObservableCollection<Car> Cars = new ObservableCollection<Car>();

        public MainWinCarShop()
        {
            InitializeComponent();
            GenerateDB();
        }
        private void GenerateDB()
        {
            // Color a =Colors.Green;
            // MessageBox.Show(a.A.ToString());
            // Color b=Colors.Yellow;//
            // Color c=new Color();
            // c =  Color.FromArgb(a.A,a.R,a.G,a.B);
            //b = a;
            // MessageBox.Show(b.A.ToString());
            // this.Background = new LinearGradientBrush(c,c,10);
        

            SQLiteConnection con = new SQLiteConnection($"Data Source={dbName}");
            con.Open();
            string query = "PRAGMA foreign_keys = ON";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.ExecuteNonQuery();
            GenerateTabels(con);
            con.Close();

        }
        private void GenerateTabels(SQLiteConnection con)
        {
            string query = $"CREATE TABLE IF NOT EXISTS {tblColor} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "A INTEGER NOT NULL, " +
                                  "R INTEGER NOT NULL, " +
                                    "G INTEGER NOT NULL, " +
                                     "B INTEGER NOT NULL "+ 
                                ")";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.ExecuteNonQuery();
            query = $"CREATE TABLE IF NOT EXISTS {tblCarMake} " +
                       "(    Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                           "Make TEXT NOT NULL UNIQUE" +
                       ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();


         
            query = $"CREATE TABLE IF NOT EXISTS {tblCarModel} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                 "Id_Make int, " +
                                    "Model TEXT NOT NULL, " +
                                 "FOREIGN KEY (Id_Make) REFERENCES tblCarMake(Id)" +

                                ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            query = $"CREATE TABLE IF NOT EXISTS {tblFuel_type} " +
                  "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                      "Fuel TEXT NOT NULL " +

                  ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();



            query = $"CREATE TABLE IF NOT EXISTS {tblTypeCar} " +
          "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
              "TypeCar TEXT NOT NULL " +

          ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();


            query = $"CREATE TABLE IF NOT EXISTS {tblCars} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Id_Color int NOT NULL, " +
                                    "Id_Model int NOT NULL, " +
                                    "Id_Make int NOT NULL, " +
                                    "Date Datetime NOT NULL, " +
                                    "Id_FuelType int NOT NULL, " +
                                    "Id_Type int NOT NULL, " +
                                    "Availability Bool NOT NULL, " +
                                    "Image Text NOT NULL, " +
                                    "Price int NOT NULL, " +
                                    "FOREIGN KEY (Id_Color) REFERENCES tblColor(Id), " +
                                    "FOREIGN KEY (Id_Model) REFERENCES tblCarModel(Id)" +
                                    "FOREIGN KEY (Id_Make) REFERENCES tblCarMake(Id)" +

                                    "FOREIGN KEY (Id_FuelType) REFERENCES tblFuel_type(Id)" +
                                    "FOREIGN KEY (Id_Type) REFERENCES tblTypeCar(Id)" +
                                   
                                ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();


            query = $"CREATE TABLE IF NOT EXISTS {tblOrder} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Id_Car int NOT NULL, " +
                                    "Id_Client int NOT NULL, " +
                                  "Date Datetime NOT NULL, " +
                                    " Total_Price int NOT NULL, " +
                                    "FOREIGN KEY (Id_Car) REFERENCES tblCar(Id), " +
                                    "FOREIGN KEY (Id_Client) REFERENCES tblClient(Id)" +
                                   

                                ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();


            query = $"CREATE TABLE IF NOT EXISTS {tblClient} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Name Text NOT NULL, " +
                                    "Image Text NOT NULL, " +

                                    "Id_Purchase int, " +

                                    " Total_Price int, " +
                                    "FOREIGN KEY (Id_Purchase) REFERENCES tblPurchase(Id) " +


                                ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();


            query = $"CREATE TABLE IF NOT EXISTS {tblPurchase} " +
                                "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                   

                                    "Id_Order int, " +

                                    " Total_Price int NOT NULL, " +
                                    "FOREIGN KEY (Id_Order) REFERENCES tblOrder(Id) " +


                                ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

        }
        private void BtnShowCar_Click(object sender, RoutedEventArgs e)
        {
            ShowCarWindow showCar = new ShowCarWindow();
           
            showCar.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEng_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["setLang"].Value = "en-US";
            config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.AppSettings["setLang"] = "ru";
            this.Restart();
        }

        private void BtnUk_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["setLang"].Value = "uk";
            config.Save(ConfigurationSaveMode.Modified);
            this.Restart();
        }
        private void Restart()
        {
            System.Diagnostics.Process
                .Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnAddClients_Click(object sender, RoutedEventArgs e)
        {
            AddClients addClients = new AddClients();

            addClients.Show();
        }

        private void BtnShowClients_Click(object sender, RoutedEventArgs e)
        {
            ShowClients showClients = new ShowClients();
            showClients.Show();
        }
    }
}
