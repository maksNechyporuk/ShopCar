using ServiceDLL.Models;
using System;
using System.Collections.Generic;
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
        List<Button> btn = new List<Button>();

        public CarsInformationWindow(CarVM car)
        {
            InitializeComponent();
            CarVM _car = car;
            lblCarsName.Content = _car.Name ;
            var imgs= Directory.GetFiles(car.Image + "/Photo");
            int count = 0;
           
            foreach (var item in imgs)
            {
                if(item.Contains("100"))
                {
             
                       var btnImg = new Button { Content = new Image { Source = new BitmapImage(new Uri(item)) }, Tag = count };
                    btnImg.Click += BtnImg_Click;
                    btn.Add(btnImg);
                    count++;
                    if (count == 8)
                        break;
                }
                if (item.Contains("1280"))
                {
                    bigImg.Add(new Image { Source = new BitmapImage(new Uri(item)) });
                }
            }
            foreach (var item in btn)
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
            var b = sender as Button;
            BigPhoto.Source = bigImg[int.Parse(b.Tag.ToString())].Source;
        }
    }
}
