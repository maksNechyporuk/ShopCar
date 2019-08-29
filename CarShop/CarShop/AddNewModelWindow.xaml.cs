using CarShop.Entities;
using CarShop.ViewModels;
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
        private ObservableCollection<ModelViewModels> ModelVM { get; set; }

        private readonly EFcontext _context;
        public static List<Make> dataSource = new List<Make>();
       
        public AddNewModelWindow()
        {
            InitializeComponent();
            _context = new EFcontext();
        //    this.cbMake.Focus();
            ModelVM = new ObservableCollection<ModelViewModels>();
            FillDG();
        }
        void FillDG()
        {
            try
            {
                var query = _context.Models.AsQueryable();
                var list = query.Select(at => new ModelViewModels
                {
                    Id = at.Id,
                    Name = at.Name,
                    Make = at.Make.Name
                }).ToList();
                ModelVM.Clear();
                ModelVM.AddRange(list);
                foreach (var u in ModelVM)
                {
                    DBGrid.Items.Add(u);
                }
                var queryMakes = _context.Makes.AsQueryable();
                var listMakes = queryMakes.Select(at => new MakeViewModels
                {
                    Id = at.Id,
                    Name = at.Name,

                }).ToList();
                cbMake.ItemsSource = listMakes;
            }
            catch { }          
        }
            private void BtnAddMake_Click(object sender, RoutedEventArgs e)
        {
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
                _context.Makes.Add(new Entities.Make { Name = txtModel.Text });
                _context.SaveChanges();
                FillDG();
            }
        }

        private void CbMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(cbMake.SelectedValue.ToString());
        }
    }
}
