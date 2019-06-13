using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace CarShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var lang = ConfigurationManager.AppSettings["setLang"];
            if(lang!=null)
            System.Threading.Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo(lang);
        }
    }
}
