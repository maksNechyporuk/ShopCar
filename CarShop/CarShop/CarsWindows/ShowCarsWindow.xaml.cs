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
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using WPFAnimal.Extensions;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CarShop.CarsWindows;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        private ObservableCollection<FNameViewModel> FilterVM { get; set; }
        private ObservableCollection<CarVM> CarVM { get; set; }
        TextBox txtSearchCar;
        public AddNewCarWindow()
        {
            InitializeComponent();
            FilterVM = new ObservableCollection<FNameViewModel>();
            CarVM = new ObservableCollection<CarVM>();
            txtSearchCar = new TextBox() { Width = 230, Margin = new Thickness(0, 10, 5, 5) };
            txtSearchCar.TextChanged += TxtSearchCar_TextChanged;
            GetFilters();

        }
        private void TxtSearchCar_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        async  void GetFilters()
        {
            FilterApiService service = new FilterApiService();
            List<FNameViewModel> list = await service.GetFiltersAsync();
            FilterVM.Clear();
            FilterVM.AddRange(list);
            CarApiService serviceCars = new CarApiService();
            var listCars = await serviceCars.GetCarsAsync();
            CarVM.Clear();
            CarVM.AddRange(listCars);
            CarVM.AddRange(listCars);
            CarVM.AddRange(listCars);
            CarVM.AddRange(listCars);
            CarVM.AddRange(listCars);
            FillFiltersWP();
            FillCarsWP();
            Spinner.Opacity=0;

        }
         void  FillCarsWP()
        {

            wpCars.Children.Clear();
            int i = 0;
            int j = 0;
            if(CarVM.Count==0)
            {
                var lbl = new Label { Content = "Даних незнайдено", FontSize = 20, Margin = new Thickness(5, 5, 5, 5) };
                Grid.SetColumn(lbl, 1);
                Grid.SetRow(lbl, 3);
                wpCars.Children.Add(lbl);

            }
            foreach (var item in CarVM)
            {               
                var wp = new StackPanel() { Margin= new Thickness(5, 5, 5, 5) };
                var img = new Image() {Height = 183, Width = 298};
                img.Source = new BitmapImage(new Uri(item.Image + "/300_" + item.UniqueName + ".jpg"));
                wp.Tag = item.UniqueName;
                wp.MouseDown += Wp_MouseDown;
                wp.Children.Add(img);
                wp.Children.Add(new Label() { Content = item.UniqueName,  Height = 33, Width = 80 });
                wp.Children.Add(new Label() { Content = "Ціна"+item.Price, FontStyle= FontStyle, Margin= new Thickness(5, 5, 5, 5), Height = 33, Width = 80 });
                Grid.SetColumn(wp, j);
                Grid.SetRow(wp, i);
                wpCars.Children.Add(wp);
                j++;
                if(j==4)
                {
                    i++;
                    j = 0;
                }

            }          
        }

        private async void Wp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel panel= sender as StackPanel;
            CarApiService service = new CarApiService();
            var car = await service.GetCarsByNameAsync(panel.Tag.ToString());
            CarsInformationWindow window = new CarsInformationWindow(car);
            window.ShowDialog();
        }


        void FillFiltersWP()
        {
            wpFilters.Children.Clear();
            wpFilters.Children.Add(txtSearchCar);
            foreach (var item in FilterVM)
            {                   
                    Label Name = new Label();
                    Name.Content = item.Name;
                    Name.Margin = new Thickness(25, 5, 15, 5);
                    wpFilters.Children.Add(Name);
                    foreach (var children in item.Children)
                    {
                        CheckBox value = new CheckBox
                        {
                            Content = children.Name,
                            Margin = new Thickness(55, 0, 5, 5),
                            Tag = children.Id
                        };
                        value.Click += Value_Click;
                        wpFilters.Children.Add(value);
                    }
                }
        }

        

        private async void Value_Click(object sender, RoutedEventArgs e)
        {
            List<CheckBox> box = new List<CheckBox>();
            foreach (var item in wpFilters.Children)
            {
                if (item.GetType() == typeof(CheckBox))

                    box.Add(item as CheckBox);
            }
            List<int> idValue = new List<int>();
            foreach (var item in box)
            {
                if (item.IsChecked == true)
                {
                    idValue.Add((int)(item.Tag));
                }
            }
            CarApiService service = new CarApiService();
            var list= await service.GetCarsByFiltersAsync(idValue.ToArray());
            CarVM.Clear();
            CarVM.AddRange(list);
            FillCarsWP();

        }

     
    }
}
