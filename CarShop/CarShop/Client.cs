using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public class ClientVM
    {
        string name;
        string clientImg;
        int id;
        string img;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
