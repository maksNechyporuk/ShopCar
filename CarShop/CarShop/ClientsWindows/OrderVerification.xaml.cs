using System;
using System.Collections.Generic;
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

namespace CarShop.ClientsWindows
{
    /// <summary>
    /// Interaction logic for OrderVerification.xaml
    /// </summary>
    public partial class OrderVerification : Window
    {
        public int verCode;
        public OrderVerification()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToInt32( txtCode.Text) == verCode)
            {
                MessageBox.Show("Замовлення успішно підтвердженно.","Підтверження.");
            }
            else
            {
                MessageBox.Show("Введений код не збігається з кодом, який був відправлений.", "Підтверження.");
            }
        }
    }
}
