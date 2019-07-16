using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class ClientViewModels : INotifyPropertyChanged
    {
        string name;
        int id;
        string img;
        string phone;
        public string PathImg
        {
            get { return this.img; }

            set
            {
                if (this.img != value)
                {
                    this.img = value;
                    this.NotifyPropertyChanged("PathImg");
                }
            }
        }
        public int Id
        {
            get { return this.id; }

            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get { return this.name; }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public string Phone
        {
            get { return this.phone; }

            set
            {
                if (this.phone != value)
                {
                    this.phone = value;
                    this.NotifyPropertyChanged("Phone");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
