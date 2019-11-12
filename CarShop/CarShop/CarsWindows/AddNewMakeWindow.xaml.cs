using Newtonsoft.Json;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
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

namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddNewMakeWindow.xaml
    /// </summary>
    public partial class AddNewMakeWindow : Window
    {
        private ObservableCollection<MakeVM> MakeVM { get; set; }

        public AddNewMakeWindow()
        {
            InitializeComponent();
            lblError.Background = Brushes.White;
            MakeVM = new ObservableCollection<MakeVM>();
            DBGrid.ItemsSource = MakeVM;
            GetMakes();
           
        }
        int pageNumber = 1;
        async void GetMakes()
        {
            MakeApiService service = new MakeApiService();
            txtMake.Clear();
            List<MakeVM> list = await service.GetMakesAsync(txtMake.Text);
            MakeVM.Clear();
            MakeVM.AddRange(list);
            FillGrid();
        }
         void FillGrid()
        {
            txtMake.Clear();
            var count = MakeVM.Count();
            int numberOfObjectsPerPage = 5;//int.Parse(cbCount.Text);
            int pages = (int)Math.Ceiling((double)count / (double)numberOfObjectsPerPage);
            GenerationBtn(pages, pageNumber);

            int begin = (pageNumber - 1) * numberOfObjectsPerPage;
            int end = pageNumber * numberOfObjectsPerPage;
            DBGrid.ItemsSource = MakeVM.Skip(numberOfObjectsPerPage * (pageNumber - 1))
            .Take(numberOfObjectsPerPage);
        }
        void ShowMessage(string mes)
        {
            mes = mes.Trim('"');
            MessageBox.Show(mes);
        }
        private async void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MakeApiService service = new MakeApiService();
                ShowMessage(await service.CreateAsync(new MakeAddModel { Name = txtMake.Text }));
                GetMakes();
                lblError.Foreground = Brushes.White;
                lblError.Content="";
            }         
            catch (WebException wex)
            {
                ShowException(wex);
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
                        }); lblError.Content = mes.Name;
                        lblError.Foreground = Brushes.Red;
                    }
                }
            }
        }
        void GenerationBtn(int pages, int pageNumber)
        {
            #region Побудова кнопок           
            var sizeButton = new Size { Width = 50, Height = 30 };
            int count_b = 0;
            wpBTN.Children.Clear();
            if (pages >= 8)
            {

                for (int i = 0; i < pages; i++)
                {



                    var b = new Button()
                    {
                        Content = $"{i + 1}",
                        Width = sizeButton.Width,
                        Height = sizeButton.Height,
                        Margin = new Thickness(5, 5, 5, 5),
                        Background = i == pageNumber - 1 ? Brushes.Green : Brushes.White
                    };
                    b.Click += B_Click; ;
                    wpBTN.Children.Add(b);




                }
                return;
            }
            else  if (pageNumber <= 5)
            {
                for (int i = 0; i < pages; i++)
                {
                    if (count_b < 7)
                    {

                        var b = new Button()
                        {
                            Content = $"{i + 1}",
                            Width = sizeButton.Width,
                            Height = sizeButton.Height,
                            Margin = new Thickness(5, 5, 5, 5),
                            Background = i == pageNumber - 1 ? Brushes.Green : Brushes.White
                        };
                        b.Click += B_Click; 
                        wpBTN.Children.Add(b);
                        count_b++;

                    }
                    else { break; }

                }
            }
           
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    var b = new Button()
                    {
                        Content = $"{i + 1}",
                        Width = sizeButton.Width,
                        Height = sizeButton.Height,
                        Margin = new Thickness(5, 5, 5, 5),
                        Background = i == pageNumber - 1 ? Brushes.Green : Brushes.White
                    };
                    b.Click += B_Click; 
                    wpBTN
                    .Children
                    .Add(b);
                }

                var l = new Label()
                {
                    Content = $"...",
                    Width = sizeButton.Width,
                    Height = sizeButton.Height,
                    Margin = new Thickness(5, 5, 5, 5),
                };
                wpBTN
               .Children
               .Add(l);

                for (int i = pageNumber - 4; i < pages; i++)
                {
                    if (count_b < 7)
                    {
                        var b = new Button()
                        {
                            Content = $"{i + 1}",
                            Width = sizeButton.Width,
                            Height = sizeButton.Height,
                            Margin = new Thickness(5, 5, 5, 5),
                            Background = i == pageNumber - 1 ? Brushes.Green : Brushes.White
                        };
                        b.Click += B_Click; 
                        wpBTN.Children.Add(b);


                        count_b++;
                    }
                    else { break; }

                }

            }

            if ((pageNumber + 4) != pages&& (pageNumber + 4) < pages)
            {
                var l = new Label()
                {
                    Content = $"...",
                    Width = sizeButton.Width,
                    Height = sizeButton.Height,
                    Margin = new Thickness(5, 5, 5, 5),
                };
                wpBTN
               .Children
               .Add(l);
            }
            if ((pageNumber + 4) <= pages)
            {         
                var b = new Button()
                {
                    Content = $"{pages}",
                    Width = sizeButton.Width,
                    Height = sizeButton.Height,
                    Margin = new Thickness(5, 5, 5, 5),
                    Background = pageNumber == pageNumber - 1 ? Brushes.Green : Brushes.White
                };
                b.Click += B_Click; 
                wpBTN
             .Children
             .Add(b);
            }
            #endregion
        }
        private void B_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            pageNumber = Convert.ToInt32(btn.Content);
            FillGrid();
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
            MakeVM make = (DBGrid.SelectedItem as MakeVM);
            txtMake.Text = make.Name;
        }
        private async void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DBGrid.SelectedItem != null)
                {
                    MakeVM make = (DBGrid.SelectedItem as MakeVM);
                    MakeApiService service = new MakeApiService();
                    int id = make.Id;
                    ShowMessage( await service.DeleteAsync(new MakelDeleteVM { Id = id }));
                    GetMakes();
                }
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DBGrid.SelectedItem != null)
                {
                    MakeApiService service = new MakeApiService();
                    MakeVM make = (DBGrid.SelectedItem as MakeVM);
                    int id = make.Id;
                    ShowMessage(await service.UpdateAsync(new MakeVM { Id = id, Name = txtMake.Text }));
                    btnUpdate.IsEnabled = false;
                    GetMakes();
                }
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }           
        }

        private  void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            GetMakes();
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }
    }
}

