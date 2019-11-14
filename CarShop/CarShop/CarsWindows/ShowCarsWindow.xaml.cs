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
using System.Configuration;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class ShowCarsWindow : Window
    {
        private ObservableCollection<FNameViewModel> FilterVM { get; set; }
        private ObservableCollection<CarsByFilterVM> CarVM { get; set; }
        TextBox txtSearchCar;
        public ShowCarsWindow()
        {
            InitializeComponent();
            FilterVM = new ObservableCollection<FNameViewModel>();
            CarVM = new ObservableCollection<CarsByFilterVM>();
            txtSearchCar = new TextBox() { Width = 230, Margin = new Thickness(0, 10, 5, 5) };
            txtSearchCar.TextChanged += TxtSearchCar_TextChanged;
            GetFilters();

        }
        private async void TxtSearchCar_TextChanged(object sender, TextChangedEventArgs e)
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
            var listCars = await service.GetCarsByFilterSearchAsync(idValue.ToArray(), txtSearchCar.Text);
            if (listCars.Count == 0)
            {
                var lbl = new Label { Content = "Даних незнайдено", FontSize = 20, Margin = new Thickness(5, 5, 5, 5) };
                Grid.SetColumn(lbl, 1);
                Grid.SetRow(lbl, 3);
                wpCars.Children.Add(lbl);
            }
                CarVM.Clear();
            CarVM.AddRange(listCars);
            FillCarsWP();
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
            FillFiltersWP();
            FillCarsWP();
            Spinner.Opacity=0;

        }
        async void  FillCarsWP()
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
                var url = ConfigurationManager.AppSettings["siteURL"];
                img.Source = new BitmapImage(new Uri($"{url}{item.Image}")); 
                wp.Tag = item.UniqueName;
                wp.MouseLeftButtonDown += Wp_MouseDown;
                wp.Children.Add(img);              
                wp.Children.Add(new Label() { Content = item.Name,FontSize=15,   Width = 250 });
                wp.Children.Add(new Label() { Content = "Ціна "+item.Price, FontSize = 15, FontStyle = FontStyle, Margin= new Thickness(5, 5, 5, 5), Height = 63, Width = 250 });
                ContextMenu update = new ContextMenu() {TabIndex=item.Id };
                MenuItem itemMenu = new MenuItem() {Header="Редагувати", TabIndex = item.Id };
                MenuItem DeleteMenu = new MenuItem() { Header = "Видалити", TabIndex = item.Id };

                DeleteMenu.Click += DeleteMenu_Click;
                itemMenu.Click += ItemMenu_Click;
                update.Items.Add(itemMenu);
                update.Items.Add(DeleteMenu);

                wp.ContextMenu = update;
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

        private async void DeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;

            CarApiService service = new CarApiService();
            await service.DeleteAsync(new CarDeleteVM { Id = menu.TabIndex }); CarApiService serviceCars = new CarApiService();
            var listCars = await serviceCars.GetCarsAsync();
            CarVM.Clear();
            CarVM.AddRange(listCars);
            FillCarsWP();
        }

        private async void ItemMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            CarApiService service = new CarApiService();
            var list = await service.GetCarForUpdateAsync(menu.TabIndex);
            UpdateCarsWindow window = new UpdateCarsWindow(list);
            window.ShowDialog();
            CarApiService serviceCars = new CarApiService();
            var listCars = await serviceCars.GetCarsAsync();
            CarVM.Clear();
            CarVM.AddRange(listCars);
            FillCarsWP();
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
            var list= await service.GetCarsByFilterSearchAsync(idValue.ToArray(),txtSearchCar.Text);
            CarVM.Clear();
            CarVM.AddRange(list);
            FillCarsWP();
        }     
    }
}
