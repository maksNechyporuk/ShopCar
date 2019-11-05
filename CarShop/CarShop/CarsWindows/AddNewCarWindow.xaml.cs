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
            foreach (var item in FilterVM)
            {
                Label Name = new Label();
                Name.Content = item.Name;
                Name.Margin = new Thickness(25, 5, 15, 5);
                spCars.Children.Add(Name);

                ComboBox box = new ComboBox();
        
                foreach (var children in item.Children)
                {
                    box.Items.Add (new ComboBoxItem () { Content = children.Name });
                    box.Margin = new Thickness(55, 0, 5, 5);
                       box.Tag = children.Id;
                    spCars.Children.Add(box);
                }
            }
        }
    }
}
