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
    /// Interaction logic for AddNewMakeWindow.xaml
    /// </summary>
    public partial class AddNewMakeWindow : Window
    {
        private ObservableCollection<MakeVM> MakeVM { get; set; }

        public AddNewMakeWindow()
        {
            InitializeComponent();
            MakeVM = new ObservableCollection<MakeVM>();
            DBGrid.ItemsSource = MakeVM;
            FillDB();
        }
        async void FillDB()
        {
            MakeApiService service = new MakeApiService();
            List<MakeVM> list = await service.GetMakesAsync();
            MakeVM.Clear();
            MakeVM.AddRange(list);
            DBGrid.ItemsSource = MakeVM;

        }
        private void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {

            MakeApiService service = new MakeApiService();

            service.Create(new MakeAddModel { Name = txtMake.Text });
            //var list = _context.Makes.AsQueryable().ToList();
            //bool c = false;
            //foreach (var item in list)
            //{
            //    if (item.Name == txtMake.Text)
            //        c = true;
            //}
            //if (c == true)
            //{
            //    MessageBox.Show("Error");
            //}
            //if (c == false)
            //{
            //    _context.Makes.Add(new Entities.Make { Name = txtMake.Text });
            //    _context.SaveChanges();
            //    FillDB();
            //}
        }

        private void DBGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // try
            {

                //   if (DBGrid.SelectedItem != null)
                //    {
                //        int ind = 0;
                //        ind = MakeVM.IndexOf(DBGrid.SelectedItem as MakeViewModels);
                //        int f = MakeVM[ind].Id;
                //        //     //DataGrid(DBGrid.SelectedItem as MakeViewModels);
                //        var itemToRemove = _context.Makes.Where(x => x.Id ==f ).ToList(); //returns a single item.

                //        if (itemToRemove != null)
                //        {
                //            _context.Makes.Remove(itemToRemove[0]);
                //            _context.SaveChanges();
                //        }


                //        _context.SaveChanges();
                //        FillDB();

                //    }
                //}
                //catch
                { }
            }
        }
    }
}
