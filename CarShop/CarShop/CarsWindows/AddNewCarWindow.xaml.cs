using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFAnimal.Extensions;

namespace CarShop.CarsWindows
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        private ObservableCollection<FNameViewModel> FilterVM { get; set; }

        public AddNewCarWindow()
        {
            InitializeComponent();
            FilterVM = new ObservableCollection<FNameViewModel>();
            FillPanel();
        }
        ComboBox models = new ComboBox();

        async void FillPanel()
        {
            spCars.Children.Clear();
            spCars.Children.Add(new Label { Content = "Характеристики авто", FontSize = 25, Margin = new Thickness(20, 15, 30, 15) });
            var listComboBox = new List<ComboBox>();

            MakeApiService makeApi = new MakeApiService();
            var listMake = await makeApi.GetMakesAsync();
            FilterApiService service = new FilterApiService();
            List<FNameViewModel> list = await service.GetFiltersAsync();
            CarApiService apiService = new CarApiService();

            Label Name = new Label();
            Name.Content ="Марка";
            Name.Width = 90;
            Name.Margin = new Thickness(20, 15, 30, 15);

            ComboBox box = new ComboBox();

            foreach (var children in listMake)
            {
                box.Items.Add(new ComboBoxItem() { Content = children.Name, Tag = children.Id });
            }
            box.SelectionChanged += Box_SelectionChanged;
            box.Name = "Марка";
            box.Width = 150;
            box.Margin = new Thickness(5, 15, 10, 15);
            spCars.Children.Add(Name);
            spCars.Children.Add(box);


            FilterVM.Clear();
            FilterVM.AddRange(list);

            models.Name = "Модель";
            models.Width = 150;
            models.Margin = new Thickness(5, 15, 10, 15);

            Name = new Label();
            Name.Content = "Модель";
            Name.Width = 90;
            Name.Margin = new Thickness(20, 15, 30, 15);
            spCars.Children.Add(Name);
            spCars.Children.Add(models);

            foreach (var item in FilterVM)
            {
                var listValue = new List<string>();
                Name = new Label();
                Name.Content = item.Name;
                Name.Width = 90;
                Name.Margin = new Thickness(20, 15, 30, 15);

                 box = new ComboBox();
                foreach (var children in item.Children)
                {
                    box.Items.Add(new ComboBoxItem() { Content = children.Name, Tag = children.Id });
                }
                string name = item.Name.Replace(" ", "_");
                box.SelectionChanged += Box_SelectionChanged;
                box.Name = name;
                box.Width = 150;
                box.Margin = new Thickness(5, 15, 10, 15);
                box.Tag = item.Id;
                if (!name.Contains("Моде"))
                {
                    spCars.Children.Add(Name);
                    spCars.Children.Add(box);
                }
            }
        }

        private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarApiService apiService = new CarApiService();

            ComboBox box = sender as ComboBox;
            List<FNameViewModel> l=new List<FNameViewModel>();
            if (box.Name.Contains("Мар"))
            {
                models.Items.Clear();
                var item=box.SelectedItem as ComboBoxItem;
                l.AddRange(apiService.GetModelsByMake(int.Parse(item.Tag.ToString())));
                foreach (var name in l)
                {
                    foreach (var children in name.Children)
                    models.Items.Add(new ComboBoxItem() { Content = children.Name, Tag = children.Id });
                }                
            }
        }
    }
}
