using CarShop.Entities;
using CarShop.ViewModels;
using ServiceDLL.Concrete;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
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


namespace CarShop
{
    /// <summary>
    /// Interaction logic for AddNewModelWindow.xaml
    /// </summary>
    ///         

    public partial class AddNewModelWindow : Window
    {
        private ObservableCollection<ModelVM> ModelVM { get; set; }

        private readonly EFcontext _context;
        public static List<Make> dataSource = new List<Make>();
       
        public AddNewModelWindow()
        {
            InitializeComponent();
            _context = new EFcontext();
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
            List<ModelVM> list = await service.GetMakesAsync();
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
        else    if (pageNumber <= 5)
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
                        b.Click += B_Click; ;
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
                    b.Click += B_Click; ;
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
                        b.Click += B_Click; ;
                        wpBTN.Children.Add(b);


                        count_b++;
                    }
                    else { break; }

                }

            }
            if ((pageNumber + 4) < pages)
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
            if ((pageNumber + 4) < pages)
            {
                var b = new Button()
                {
                    Content = $"{pages}",
                    Width = sizeButton.Width,
                    Height = sizeButton.Height,
                    Margin = new Thickness(5, 5, 5, 5),
                    Background = pageNumber == pageNumber - 1 ? Brushes.Green : Brushes.White
                };
                b.Click += B_Click; ;
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



        private void BtnAddModel_Click(object sender, RoutedEventArgs e)
        {
            if (cbMake.Text != "" && txtModel.Text != "")
            {
                ModelApiService service = new ModelApiService();

                MakeVM make = (cbMake.SelectedItem as MakeVM);

                service.Create(new ModelAddVM { Name = txtModel.Name ,Make=make});
                var list = _context.Models.AsQueryable().ToList();
                bool c = false;
                foreach (var item in list)
                {
                    if (item.Name == txtModel.Text)
                        c = true;
                }
                if (c == true)
                {
                    MessageBox.Show("Error");
                }
                if (c == false)
                {
                    _context.Models.Add(new Entities.Model { MakeId = int.Parse(cbMake.SelectedValue.ToString()), Name = txtModel.Text });
                    _context.SaveChanges();
                    txtModel.Clear();

                    FillGrid();
                }
            }
            else
            {
                MessageBox.Show("Please, fill all lines.");

            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
