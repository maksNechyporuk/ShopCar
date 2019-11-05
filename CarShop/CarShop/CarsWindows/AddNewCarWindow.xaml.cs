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

        async void FillPanel()
        {
            FilterApiService service = new FilterApiService();
            List<FNameViewModel> list = await service.GetFiltersAsync();
            FilterVM.Clear();
            FilterVM.AddRange(list);
            spCars.Children.Clear();
            spCars.Children.Add(new Label { Content = "Характеристики авто", FontSize = 25,Margin = new Thickness(20, 15, 30, 15) });

            foreach (var item in FilterVM)
            {
                var listValue = new List<string>();

                Label Name = new Label();
                Name.Content = item.Name;
                Name.Width = 90;

                Name.Margin = new Thickness(20, 15, 30, 15);
                spCars.Children.Add(Name);
                ComboBox box = new ComboBox();

                foreach (var children in item.Children)
                {
                    box.Items.Add(new ComboBoxItem() { Content = children.Name,Tag=children.Id });
                }
                box.Width = 150;
                box.Margin = new Thickness(5, 15, 10, 15);
                box.Tag=item.Id;
                spCars.Children.Add(box);
            }
        }
    }
}
