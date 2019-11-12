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
    /// Interaction logic for AddNewModelWindow.xaml
    /// </summary>
    ///         

    public partial class AddNewModelWindow : Window
    {
        private ObservableCollection<ModelVM> ModelVM { get; set; }

        //private readonly EFcontext _context;
        //public static List<Make> dataSource = new List<Make>();
       
        public AddNewModelWindow()
        {
            InitializeComponent();
            //_context = new EFcontext();
            this.cbMake.Focus();
            ModelVM = new ObservableCollection<ModelVM>();
            FillGrid();
        }
        int pageNumber = 1;

        async void FillGrid()
        {
            MakeApiService serviceMake = new MakeApiService();

            var listMake = await serviceMake.GetMakesAsync();
            cbMake.ItemsSource = listMake;
            ModelApiService service = new ModelApiService();
            List<ModelVM> list = await service.GetModelsAsync(txtModel.Text);
            ModelVM.Clear();
            ModelVM.AddRange(list);

            var count = ModelVM.Count();
            int numberOfObjectsPerPage = 10;//int.Parse(cbCount.Text);
            int pages = (int)Math.Ceiling((double)count / (double)numberOfObjectsPerPage);
            GenerationBtn(pages, pageNumber);

            int begin = (pageNumber - 1) * numberOfObjectsPerPage;
            int end = pageNumber * numberOfObjectsPerPage;
            DBGrid.ItemsSource = ModelVM.Skip(numberOfObjectsPerPage * (pageNumber - 1))
            .Take(numberOfObjectsPerPage);
        
        }

        void GenerationBtn(int pages, int pageNumber)
        {
            #region Побудова кнопок           
            var sizeButton = new System.Drawing.Size { Width = 50, Height = 30 };
            int count_b = 0;
            wpBTN.Children.Clear();
            if(pages>=8)
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
            else if (pageNumber <= 5)
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

            if ((pageNumber + 4) != pages && (pageNumber + 4) < pages)
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
        private async void BtnAddModel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblErrorModel.Foreground = Brushes.White;
                lblErrorMake.Foreground = Brushes.White;
                lblErrorMake.Content = "";
                lblErrorModel.Content = "";
                ModelApiService service = new ModelApiService();
                MakeVM make = (cbMake.SelectedItem as MakeVM);
                ShowMessage(await service.CreateAsync(new ModelAddVM { Name = txtModel.Text, Make = make }));
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
                            Name ="",
                            Make=""
                        });
                        if (mes.Make != null)
                        {
                            lblErrorMake.Content = mes.Make;
                        }
                        if (mes.Name != null)
                        {
                            lblErrorModel.Content = mes.Name;
                        }
                        lblErrorMake.Foreground = Brushes.Red;
                        lblErrorModel.Foreground = Brushes.Red;
                    }
                }
            }
        }
        void ShowMessage(string mes)
        {
            mes = mes.Trim('"');
            MessageBox.Show(mes);
        }
        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DBGrid.SelectedItem != null)
                {
                    ModelApiService service = new ModelApiService();
                    MakeVM make = (cbMake.SelectedItem as MakeVM);
                    ModelVM model = (DBGrid.SelectedItem as ModelVM);
                    ShowMessage(await service.UpdateAsync(new ModelVM {Id= model.Id, Name =txtModel.Text,Make=make}));
                    btnUpdate.IsEnabled = false;
                    //GetMakes();
                }
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
            ModelVM model = (DBGrid.SelectedItem as ModelVM);
            txtModel.Text = model.Name;
            cbMake.Text = model.Make.Name;
        }
        private async void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DBGrid.SelectedItem != null)
                {
                    ModelVM make = (DBGrid.SelectedItem as ModelVM);
                    ModelApiService service = new ModelApiService();
                    int id = make.Id;
                    ShowMessage(await service.DeleteAsync(new ModelDeleteVM { Id = id }));
                   //GetMakes();
                }
            }
            catch (WebException wex)
            {
                ShowException(wex);
            }
        }
    }
}
