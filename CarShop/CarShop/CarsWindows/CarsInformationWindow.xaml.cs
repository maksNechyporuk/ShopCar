using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

namespace CarShop.CarsWindows
{
    /// <summary>
    /// Interaction logic for CarsInformationWindow.xaml
    /// </summary>
    public partial class CarsInformationWindow : Window
    {
        CarVM _car;
        public CarsInformationWindow()
        {
            InitializeComponent();
        }
        List<Image> bigImg = new List<Image>();
        List<StackPanel> img = new List<StackPanel>();

        public CarsInformationWindow(CarVM car)
        {
            InitializeComponent();
            _car = car;
            lblCarsName.Content = _car.Name ;
            var url = ConfigurationManager.AppSettings["siteURL"];
            var path= $"{url}{_car.Image}";
            CarApiService service = new CarApiService();
            var imgs = service.GetImagesBySize(_car.UniqueName,"100");
            var Bigimgs = service.GetImagesBySize(_car.UniqueName, "1280");

            int count = 0;
            
            foreach (var item in imgs)
            {


                var WrapImg = new StackPanel {  Tag = count };
                WrapImg.Children.Add(new Image { Source = new BitmapImage(new Uri(item)) });
                WrapImg.MouseDown += BtnImg_Click;
                img.Add(WrapImg);
                count++;
                if (count == 8)
                    break;
            }
                foreach (var item in Bigimgs)
                {
                    
                    bigImg.Add(new Image { Source = new BitmapImage(new Uri(item)) });
                }
            
            foreach (var item in img)
            {
                spLitleCarsPhoto.Children.Add(item);

            }
            BigPhoto.Source = bigImg[0].Source;
            lblPrice.Content += _car.Price.ToString();
            spCharacteristics.Children.Add(new Label { Content = "Характеристики авто", FontSize=25});

            foreach (var item in car.filters)
            {
                spCharacteristics.Children.Add(new Label { Content = item.Name+": "+item.Children, FontSize = 18 });
            }
        }

        private void BtnImg_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as StackPanel;
            BigPhoto.Source = bigImg[int.Parse(b.Tag.ToString())].Source;
        }
    }
}
