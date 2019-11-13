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

namespace CarShop.OrderWindows
{
    /// <summary>
    /// Interaction logic for ShowOrderWindow.xaml
    /// </summary>
    public partial class ShowOrderWindow : Window
    {
        private ObservableCollection<OrderShowVM> Orders { get; set; }

        OrderVM order;
        public ShowOrderWindow()
        {
            InitializeComponent();
            Orders = new ObservableCollection<OrderShowVM>();
            GetOrders();

        }
        async void GetOrders()
        {
            OrderApiService service = new OrderApiService();
           
            List<OrderShowVM> list = await service.GetOrdersAsync();
            Orders.Clear();
            Orders.AddRange(list);
            FillGrid();
        }
        void FillGrid()
        {

            DBGrid.ItemsSource = Orders;
        }
    }
}
