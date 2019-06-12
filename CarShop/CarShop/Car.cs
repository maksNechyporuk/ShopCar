using System;
using System.ComponentModel;
using System.Windows.Media;


namespace CarShop
{
    public class Car
    {
        Color color;
        int id;
        string make;
        string model;
        DateTime date;
        string fuelType;
        string type;
        bool availability;
        public bool Availability
        {
            get { return this.availability; }

            set
            {
                if (this.availability != value)
                {
                    this.availability = value;
                    this.NotifyPropertyChanged("Availability");
                }
            }
        }
        public string Type
        {
            get { return this.type; }

            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    this.NotifyPropertyChanged("Type");
                }
            }
        }
        public string FuelType
        {
            get { return this.fuelType; }

            set
            {
                if (this.fuelType != value)
                {
                    this.fuelType = value;
                    this.NotifyPropertyChanged("FuelType");
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
        public Color Color
        {
            get { return this.color; }

            set
            {
                if (this.color != value)
                {
                    this.color = value;
                    this.NotifyPropertyChanged("Color");
                }
            }
        }
        public string Model
        {
            get { return this.model; }

            set
            {
                if (this.model != value)
                {
                    this.model = value;
                    this.NotifyPropertyChanged("Model");
                }
            }
        }
        public string Make
        {
            get { return this.make; }

            set
            {
                if (this.make != value)
                {
                    this.make = value;
                    this.NotifyPropertyChanged("Make");
                }
            }
        }
        int price;
        public int Price
        {
            get { return this.price; }

            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.NotifyPropertyChanged("Price");
                }
            }
        }
        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.NotifyPropertyChanged("Date");
                }
            }
        }
        public Car()
        {

        }
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
        public Car(string n, int a, DateTime d, string path)
        {
            Make = n;
            Price = a;
            Date = d;
            PathImg = path;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }



}

