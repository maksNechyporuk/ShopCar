using Microsoft.Win32;
using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFAnimal.Extensions;

namespace CarShop.CarsWindows
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        List<Image> bigImg = new List<Image>();
        List<StackPanel> img = new List<StackPanel>();
        string CarsMake;
        string CarsModel;
        private ObservableCollection<FNameViewModel> FilterVM { get; set; }
        string main_base64Image;
        List<string> additional_base64Image;
       public int[] id;
 
        public CarAddVM readyCar;
        CarUpdateVM carUpdateVM;
        ComboBox make = new ComboBox();
        public AddNewCarWindow()
        {
            InitializeComponent();
            additional_base64Image = new List<string>();
            FilterVM = new ObservableCollection<FNameViewModel>();
            FillPanel();
        }      
        ComboBox models = new ComboBox();

              
        private void BtnImg_Click(object sender, MouseButtonEventArgs e)
        {
            var b = sender as StackPanel;
            BigPhoto.Source = bigImg[int.Parse(b.Tag.ToString())].Source;
        }

        //async void FillMake(int id)
        //{
        //    MakeApiService service = new MakeApiService();
        //    var makes = service.GetMakeByModels(id); 
        //    var listMake = await service.GetMakesAsync();
        //    foreach (var children in listMake)
        //    {
        //        var BoxItem = new ComboBoxItem() { Content = children.Name, TabIndex = children.Id };
        //        make.Items.Add(BoxItem);
        //        if(BoxItem.TabIndex==makes)
        //        {
        //            make.SelectedItem = BoxItem;
        //        }
        //    }
        //    make.SelectionChanged += Box_SelectionChanged;
        //}
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
            Name.FontSize = 15;

            ComboBox box = new ComboBox();

            foreach (var children in listMake)
            {
                box.Items.Add(new ComboBoxItem() { Content = children.Name, TabIndex = children.Id });
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
            Name.FontSize = 15;
            Name.Width = 90;
            Name.Margin = new Thickness(20, 15, 30, 15);
            spCars.Children.Add(Name);
            models.SelectionChanged += Models_SelectionChanged;
            spCars.Children.Add(models);
            id= new int[FilterVM.Count];
            int i = 0;
            foreach (var item in FilterVM)
            {
                string name = item.Name.Replace(" ", "_");
              
                if (name!=("Модель"))
                {
                    int j = i;
                    var listValue = new List<string>();
                Name = new Label();
                Name.Content = item.Name;
                Name.Width = 90;
                Name.Margin = new Thickness(20, 15, 30, 15);
                Name.FontSize = 15;
                box = new ComboBox() {TabIndex=i};
                foreach (var children in item.Children)
                {
                    box.Items.Add(new ComboBoxItem() { Content = children.Name, TabIndex = children.Id });
                }
                box.SelectionChanged += Box_SelectionChanged1;
                box.Name = name;
                box.Width = 150;
                box.Margin = new Thickness(5, 15, 10, 15);
                box.Tag = item.Id;
              
                    
                    spCars.Children.Add(Name);
                    spCars.Children.Add(box);
                 
                }
                else
                continue;
                i++;

            }
        }
        private void Box_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            var item = box.SelectedItem as ComboBoxItem;
            id[box.TabIndex] = item.TabIndex;
        }
        private void Models_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox box = sender as ComboBox;
                var item = box.SelectedItem as ComboBoxItem;
                id[id.Count()-1] = item.TabIndex;
                CarsModel = item.Content.ToString();
            }
            catch { }
            }
        private void Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarApiService apiService = new CarApiService();

            ComboBox box = sender as ComboBox;
            List<FNameViewModel> l=new List<FNameViewModel>();                        
                models.Items.Clear();
                var item=box.SelectedItem as ComboBoxItem;
                CarsMake = item.Content + " ";
                l.AddRange(apiService.GetModelsByMake(item.TabIndex));
                foreach (var name in l)
                {
                    foreach (var children in name.Children)
                    models.Items.Add(new ComboBoxItem() { Content = children.Name, TabIndex = children.Id });
                }                           
        }

        private async void BtnAddNewCar_Click(object sender, RoutedEventArgs e)
        {
            if (IfNotEmpty())
            {
                CarApiService service = new CarApiService();

                int idCar = await service.CreateAsync(new CarAddVM
                {
                    AdditionalImage = additional_base64Image,
                    Count = int.Parse(txtCount.Text),
                    Date = dpDate.SelectedDate.Value,
                    MainImage = main_base64Image,
                    Price = decimal.Parse(txtPrice.Text),
                    UniqueName = Guid.NewGuid().ToString(),
                    Name = CarsMake + CarsModel
                });
                await service.CreateAsyncFilterWithCars(new FilterAddWithCarVM { IdValue = id, IdCar = idCar });
                Close();
            }
        }
        private void BtnMainImg_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
                "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (dlg.ShowDialog() == true)
            {
                BigPhoto.Source = new BitmapImage(new Uri(dlg.FileName));
                var b = ConvertBitmapSourceToByteArray(BigPhoto.Source as BitmapSource);
                main_base64Image = Convert.ToBase64String(b);
            }
        }
        void ShowException(WebException wex)
        {
            if (wex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)wex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var error = reader.ReadToEnd();
                        var mes = JsonConvert.DeserializeAnonymousType(error, new
                        {
                            Name = ""
                        });
                    }
                }
            }
        }
        private  bool IfNotEmpty()
        {
            List<ComboBox> boxes = new List<ComboBox>();
            foreach (var item in spCars.Children)
            {
                if(item is ComboBox)
                {
                    boxes.Add(item as ComboBox);
                }
            }
            int count = 0;
            foreach (var item in boxes)
            {
                if(item.SelectedItem==null)
                {
                    item.BorderBrush= new SolidColorBrush(Colors.Red);
                    count++;
                }
            }
            if(txtCount.Text=="")
            {
                txtCount.BorderBrush = new SolidColorBrush(Colors.Red); count++;
            }
            if ( txtPrice.Text == "")
            {
                txtPrice.BorderBrush = new SolidColorBrush(Colors.Red); count++;
            }
            if (dpDate.SelectedDate == null)
            {
                dpDate.BorderBrush = new SolidColorBrush(Colors.Red); count++;
            }
            if (BigPhoto.Source==null)
            {
                count++;
                btnMainImg.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (spLitleCarsPhoto.Children.Count==0)
            {
                count++;
                btnAdditionalImg.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (count==0)
            return true;
            else
            {
                MessageBox.Show("Заповніть усі поля");
                return false;
            }
        }
        private void BtnAdditionalImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) " +
            "| *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == true)
            {
                foreach (var item in dlg.FileNames)
                {
                    var WrapImg = new StackPanel { };
                    var img = new Image { Source = new BitmapImage(new Uri(item)) };
                    WrapImg.Children.Add(img);
                    var b = ConvertBitmapSourceToByteArray(img.Source as BitmapSource);
                    var i = Convert.ToBase64String(b);
                    additional_base64Image.Add(i);
                    spLitleCarsPhoto.Children.Add(WrapImg);
                }
               
            }
        }
        public static byte[] ConvertBitmapSourceToByteArray(BitmapSource image)
        {
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        //private async void Window_Closed(object sender, EventArgs e)
        //{
        //    var b = ConvertBitmapSourceToByteArray(BigPhoto.Source as BitmapSource);
        //    main_base64Image = Convert.ToBase64String(b);
        //    GC.Collect();
        //    readyCar= new CarAddVM
        //    {
        //        Id=carUpdateVM.Id,
        //        AdditionalImage = additional_base64Image,
        //        Count = int.Parse(txtCount.Text),
        //        Date = dpDate.SelectedDate.Value,
        //        MainImage = main_base64Image,
        //        Price = decimal.Parse(txtPrice.Text),
        //        UniqueName = /*Guid.NewGuid().ToString(),//*/carUpdateVM.UniqueName,
        //        Name = CarsMake + CarsModel
        //    };
        //}

        
    }

}
